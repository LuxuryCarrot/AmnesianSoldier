using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum EnemyState
{
    IDLE = 0,
    BATTLE,
    KNOCKBACK,
    DIE
}
public class EnemyManager : MonoBehaviour
{
    //공격타입
    public AttackType[] attackType;
    //현재 상태
    public EnemyState current;
    //속도
    public float ySpeed;
    public float gravity;
    public float range;
    //FSM 저장부
    Dictionary<EnemyState, EnemyParent> EnemyFlow = new Dictionary<EnemyState, EnemyParent>();
    //여기에 붙어있는 화살표 이미지.
    public static GameObject PosImage;
    public Animator anim;

    public EnemyAwakeParent awakeBehavior;
    public EnemyBattleParent battleBehavior;
    public EnemyDieParent dieBehavior;
    


    private void Awake()
    {
        
        if (gravity == 0)
            gravity = 10.0f;
        for(int i=0; i<attackType.Length; i++)
           attackType[i] = (AttackType)((int)Random.Range(0, 3));
        anim = GetComponentInChildren<Animator>();
        current = EnemyState.IDLE;
        EnemyFlow.Add(EnemyState.IDLE, GetComponent<EnemyWait>());
        EnemyFlow.Add(EnemyState.DIE, GetComponent<EnemyDie>());
        if (PosImage == null)
            PosImage = Resources.Load("Prefabs/Cards/EmptyCard") as GameObject;

        //카드를 붙인 뒤, 그 카드의 타입에 따라 위치 정규화. 카드 이미지가 생긴 뒤 수정할 파트.
        for (int i = 0; i < attackType.Length; i++)
        {
            GameObject newPosCard = Instantiate(PosImage, transform.GetChild(1));
            if (attackType[i] == AttackType.UP)
                newPosCard.transform.Rotate(0, 0, -90);
            else if (attackType[i] == AttackType.DOWN)
                newPosCard.transform.Rotate(0, 0, 90);
            else if (attackType[i] == AttackType.RIGHT)
                newPosCard.transform.Rotate(0, 0, 180);

            //사이즈를 월드 사이즈로 변경.
            newPosCard.GetComponent<RectTransform>().sizeDelta = new Vector2(1, 1);
            //위치 표시.
            newPosCard.GetComponent<RectTransform>().localPosition = new Vector3(i, 1.5f, 0);
        }
        awakeBehavior = GetComponent<EnemyAwakeParent>();
        battleBehavior = GetComponent<EnemyBattleParent>();
        dieBehavior = GetComponent <EnemyDieParent > ();
        

        
        EnemyFlow.Add(EnemyState.KNOCKBACK, GetComponent<EnemyKnockBack>());
        SetState(current);
    }

    public void SetState(EnemyState newst)
    {
        foreach (EnemyParent currentstage in EnemyFlow.Values)
        {
            if (currentstage.enabled == true)
                currentstage.EndState();
            currentstage.enabled = false;
        }
        current = newst;
        EnemyFlow[current].enabled = true;
        EnemyFlow[current].BeginState();
    }
    private void Update()
    {
        //땅에 떨어지는 부분.
        if (!GetComponent<CharacterController>().isGrounded)
        {
            ySpeed += gravity * Time.deltaTime;
            GetComponent<CharacterController>().Move(new Vector3(0, -ySpeed * Time.deltaTime, 0));
        }
        else
        {
            ySpeed = 0.1f;
            GetComponent<CharacterController>().Move(new Vector3(0, -ySpeed * Time.deltaTime, 0));
        }

        //일정 높이이상 떨어지면 사라짐.
        if (transform.position.y <= -3.0f)
        {
            MonsterManager.Monsters.Remove(this.gameObject);
            Destroy(this.gameObject);
           
        }

        //플레이어가 범위 내이며, 플레이어가 기본 상태면 플레이어에 타겟이 자신이라고 넣어주는 부분.
        if (transform.position.x - PlayerManager.playerSingleton.transform.position.x <=range &&
            transform.position.x - PlayerManager.playerSingleton.transform.position.x >=0
            && PlayerManager.playerSingleton.current==PlayerState.IDLE
            )
        {
            if (PlayerManager.playerSingleton.iteratingEnemy == null)
                PlayerManager.playerSingleton.iteratingEnemy = this;
            if (awakeBehavior != null)
                awakeBehavior.Execute();
        }
    }
}
