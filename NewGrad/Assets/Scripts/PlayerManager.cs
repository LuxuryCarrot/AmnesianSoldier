﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//플레이어의 상태
public enum PlayerState
{
    DELAY=0,
    IDLE,
    MONSTERBATTLE,
    BOSSBATTLE,
    KNOCKBACK,
    ABANDON,
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

    public float ySpeed=0;
    public float gravity;
    public float range;
    public float attackRange;
    public bool losed;

    //상태를 넣는 dictionary
    Dictionary<PlayerState, PlayerParent> PlayerFlow = new Dictionary<PlayerState, PlayerParent>();
    //float commandTimeTemp=0.5f;

    private void Awake()
    {
        losed = false;
        //싱글톤 초기화
        if (playerSingleton == null)
            playerSingleton = this;
        if(HP==0)
          HP = 3;
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
        attackType.Clear();
        current = PlayerState.DELAY;
        SetState(current);
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
        if(!GetComponent<CharacterController>().isGrounded && transform.position.y > -3.0f)
        {
            ySpeed += gravity * Time.deltaTime;
            controller.Move(new Vector3(0, -ySpeed * Time.deltaTime, 0));
        }
        else
        {
            ySpeed = 0;
        }
        if(transform.position.y<=-3.0f)
            SetState(PlayerState.DIE);

        Camera.main.transform.position = transform.position + camPos;

        if(HP <=0)
        {
            SetState(PlayerState.DIE);
        }
    }
    
}