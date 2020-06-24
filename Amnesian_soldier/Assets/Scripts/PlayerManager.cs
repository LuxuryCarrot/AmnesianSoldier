﻿using System.Collections;
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
    NEXTBATTLE,
    DIE
}

//플레이어 매니저.
public class PlayerManager : MonoBehaviour
{
    //현재 타게팅 된 적
    public EnemyManager iteratingEnemy;
    public InputCardParent inputcard;
    //플레이어 싱글톤
    public static PlayerManager playerSingleton;
    //속도 벡터. 인스펙터에서 수정가능.
    public Vector3 speed;
    //입력받은 카드
    public CardParent cardInput;
    public int HP;
    //이 캐릭터 상단의 사용중인 카드 표시창
    public GameObject inputSlot;
    //현재 상태
    public PlayerState current;
    //이 캐릭터의 캐릭터 컨트롤러. 물리부
    public CharacterController controller;
    //카메라 위치보정 벡터
    public Vector3 camPos;
    //공격타입.
    public Queue<AttackType> attackType = new Queue<AttackType>();
    //하단 UI
    public GameObject CardDeckUI;

    public Animator anim;

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

    public float timeScale;
    public GameObject fillCanvas;
    public bool grounded;

    //상태를 넣는 dictionary
    Dictionary<PlayerState, PlayerParent> PlayerFlow = new Dictionary<PlayerState, PlayerParent>();
    //float commandTimeTemp=0.5f;

    private void Awake()
    {
        grounded = false;
        timeScale = 1;
        maxCamScale = Camera.main.fieldOfView;
        losed = false;
        //싱글톤 초기화
        if (playerSingleton == null)
            playerSingleton = this;
        if(HP==0)
          HP = 5;
        anim = GetComponentInChildren<Animator>();
        fillCanvas = transform.GetChild(3).gameObject;
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
        PlayerFlow.Add(PlayerState.NEXTBATTLE, GetComponent<PlayerNextBattle>());
        attackType.Clear();
        current = PlayerState.DELAY;
        SetState(current);
        AimSpawn();
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
        
        //아래의 발판이 없을때 빠지는 부분
        if(!GetComponent<CharacterController>().isGrounded && transform.position.y > -3.0f && !grounded)
        {
            
            ySpeed += gravity * Time.deltaTime;
            controller.Move(new Vector3(0, -ySpeed * Time.deltaTime, 0));
            grounded = true;
        }
        else
        {
            ySpeed = 0;
        }
        if(transform.position.y<=-3.0f && current!=PlayerState.DIE)
            SetState(PlayerState.DIE);

        if(Camera.main.transform.parent==null 
            && (StageManager.stageSingletom.current==StageState.IDLE || StageManager.stageSingletom.current == StageState.REST) && transform.position.x>=-5)
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
                attackType.Clear();
                
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
}