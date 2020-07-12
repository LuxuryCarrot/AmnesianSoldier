using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//플레이어의 상태
public enum PlayerState
{
    DELAY=0,
    IDLE,
    MONSTERBATTLE,
    BOSSBATTLE,
    KNOCKBACK,
    ABANDON,
    PINN,
    DIE,
    JUMP
}

//플레이어 매니저.
public class PlayerManager : MonoBehaviour
{
    //현재 타게팅 된 적
    public EnemyManager iteratingEnemy;
    public BossManager boss;
    public TrapParent trap;
    public InputCardParent inputcard;
    public WeaponParent weapon;
    //플레이어 싱글톤
    public static PlayerManager playerSingleton;
    //속도 벡터. 인스펙터에서 수정가능.
    public Vector3 speed;
    //입력받은 카드
    public CardParent cardInput;
    public float HP;
    public float HPMAX=5;
    //이 캐릭터 상단의 사용중인 카드 표시창
    public GameObject inputSlot;
    //현재 상태
    public PlayerState current;
    //이 캐릭터의 캐릭터 컨트롤러. 물리부
    public CharacterController controller;
    //카메라 위치보정 벡터
    public Vector3 camPos;
    //공격타입.
    public AttackType attackType = AttackType.NONE;
    //하단 UI
    public GameObject CardDeckUI;

    public Animator anim;
    public float damage;
    
    public float ySpeed=0;
    public float gravity;
    public float range;
    public float attackRange;
    public bool losed;
    public float inputTemp;

    public float minCamScale;
    public float maxCamScale;

    public float AimStartRange;
    public float AimEndRange;
    public float stam;

    public float timeScale;
    public GameObject fillCanvas;
    public bool grounded;

    public float speedIncrease=1;
    public float burftemp=0;

    public float stamRestore;

    //상태를 넣는 dictionary
    Dictionary<PlayerState, PlayerParent> PlayerFlow = new Dictionary<PlayerState, PlayerParent>();
    //float commandTimeTemp=0.5f;

    private void Awake()
    {
        if (damage == 0)
            damage = 1;
        stam = 100;
        grounded = false;
        timeScale = 1;
        maxCamScale = Camera.main.fieldOfView;
        losed = false;
        //싱글톤 초기화
        if (playerSingleton == null)
            playerSingleton = this;
        if(HP==0)
          HP = HPMAX;
        anim = GetComponentInChildren<Animator>();
        fillCanvas = transform.GetChild(2).gameObject;
        fillCanvas.SetActive(false);
        //각종 외부 상호작용 오브젝트들 초기화
        controller = GetComponent<CharacterController>();
        CardDeckUI = GameObject.FindGameObjectWithTag("CardDeck");
        inputSlot = transform.GetChild(1).gameObject;
        PlayerFlow.Add(PlayerState.DELAY, GetComponent<PlayerDelay>());
        PlayerFlow.Add(PlayerState.IDLE, GetComponent<PlayerIdle>());
        PlayerFlow.Add(PlayerState.MONSTERBATTLE, GetComponent<PlayerBattle>());
        PlayerFlow.Add(PlayerState.KNOCKBACK, GetComponent<PlayerKnockBack>());
        PlayerFlow.Add(PlayerState.DIE, GetComponent<PlayerDie>());
        PlayerFlow.Add(PlayerState.ABANDON, GetComponent<PlayerAbandon>());
        PlayerFlow.Add(PlayerState.PINN, GetComponent<PlayerPinning>());
        PlayerFlow.Add(PlayerState.JUMP, GetComponent<PlayerJump>());
        PlayerFlow.Add(PlayerState.BOSSBATTLE, GetComponent<PlayerBossBattle>());
        //PlayerFlow.Add(PlayerState.NEXTBATTLE, GetComponent<PlayerNextBattle>());
        attackType = AttackType.NONE;
        current = PlayerState.DELAY;
        SetState(current);
        //AimSpawn();
        stamRestore = 0.5f;
    }

    //상태 변경 함수
    public void SetState(PlayerState newst)
    {
        foreach(PlayerParent parent in PlayerFlow.Values)
        {
            if(parent.enabled)
            {
                parent.EndState();
                parent.enabled = false;
            }

        }
        current = newst;
        PlayerFlow[current].enabled = true;
        PlayerFlow[current].BeginState();
    }

    private void Update()
    {
        if(stam>=100 && StageManager.stageSingletom.StaminarSlot.gameObject.activeInHierarchy)
        {
            StageManager.stageSingletom.StaminarSlot.transform.parent.gameObject.SetActive(false);
        }
        else if(stam<100)
            StageManager.stageSingletom.StaminarSlot.transform.parent.gameObject.SetActive(true);
        //아래의 발판이 없을때 빠지는 부분
        if (!GetComponent<CharacterController>().isGrounded && transform.position.y > 1.0f)
        {
            
            ySpeed += gravity * Time.deltaTime;
            controller.Move(new Vector3(0, -ySpeed * Time.deltaTime, 0));
            
        }
        else if(!GetComponent<CharacterController>().isGrounded && transform.position.y > -3.0f)
        {
            ySpeed += gravity * Time.deltaTime*3;
            controller.Move(new Vector3(0, -ySpeed * Time.deltaTime, 0));
        }
        else
        {
            ySpeed = 0;
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (stam >= 25)
            {
                stam -= 25;
                stamRestore = 0.5f;
                if (trap != null &&
                    trap.transform.position.x - transform.position.x <= trap.maxRange
                    && trap.transform.position.x - transform.position.x >= trap.minRange)
                {
                    trap.SpaceIterat();
                }
            }
        }


        if (transform.position.y<=-3.0f && current!=PlayerState.DIE)
            SetState(PlayerState.DIE);

        if (transform.position.y <= 1)
            Camera.main.transform.SetParent(null);
        else if (Camera.main.transform.parent==null 
            && (StageManager.stageSingletom.current==StageState.IDLE || StageManager.stageSingletom.current == StageState.REST || StageManager.stageSingletom.current ==StageState.STORE || StageManager.stageSingletom.current == StageState.BOSSBATTLE)
            && transform.position.x>=-5)
        {
            Camera.main.transform.position = transform.position + camPos;
            Camera.main.transform.SetParent(transform);
        }

        if (StageManager.stageSingletom.current == StageState.MAPSELECT && Camera.main.transform.parent != null)
            Camera.main.transform.SetParent(null);

        if(HP <=0 && current != PlayerState.DIE)
        {
            SetState(PlayerState.DIE);
        }

        if(inputTemp>0 && iteratingEnemy==null)
        {
            inputTemp -= Time.deltaTime;
            if (inputTemp <= 0)
            {
                inputTemp = 0;
                
            }
        }

        if(trap !=null && trap.transform.position.x < transform.position.x)
        {
            trap = null;
        }


        if(burftemp!=0)
        {
            burftemp -= Time.deltaTime;
            if(burftemp<=0)
            {
                burftemp = 0;
                speedIncrease = 1;
            }
        }
    }

    public void AimSpawn()
    {
        Vector3 inst =  new Vector3((AimStartRange + AimEndRange) / 2, 1.5f, 0);
        inst.x -= camPos.x;
        Vector3 screenPos;

        Vector3 inst2 = new Vector3(AimStartRange, 0, 0);
        Vector3 inst3 = new Vector3(AimEndRange, 0, 0);

        Vector3 screenPos2 = Camera.main.WorldToScreenPoint(inst2);
        Vector3 screenPos3 = Camera.main.WorldToScreenPoint(inst3);

        screenPos = Camera.main.WorldToScreenPoint(inst);
        
        GameObject aim = Instantiate(Resources.Load("Prefabs/UIPrefab/Aim") as GameObject, StageManager.stageSingletom.aimCanvas.transform);
        aim.GetComponent<RectTransform>().position = screenPos;
        aim.GetComponent<RectTransform>().sizeDelta = new Vector2(1, 1) * (screenPos2.x - screenPos3.x);
    }
    public void AimChange(bool target)
    {
        
        if (target)
            StageManager.stageSingletom.aimCanvas.transform.GetChild(0).GetComponent<Image>()
                .sprite = Resources.Load<Sprite>("Sprites/NewUis/aim_active");
        else
            StageManager.stageSingletom.aimCanvas.transform.GetChild(0).GetComponent<Image>()
                .sprite = Resources.Load<Sprite>("Sprites/NewUis/aim_Idle");

    }

    public void AnimSettle()
    {
        anim = GetComponentInChildren<Animator>();
    }
}
