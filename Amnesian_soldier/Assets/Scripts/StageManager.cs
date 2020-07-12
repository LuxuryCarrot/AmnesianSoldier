using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//스테이지 상태를 나타내는 열거
public enum StageState
{
    READY = 0,
    IDLE,
    MONSTERBATTLE,
    BOSSBATTLE,
    MAPSELECT,
    GAMEOVER,
    GAMECLEAR,
    REST,
    WEAPONSELECT,
    STORE
}
//공격타입
public enum AttackType
{
    GUARD,
    VERTICAL,
    HORIZON,
    DOWN,
    NONE
}
//전투결과
public enum BattleResult
{
    WIN=0,
    LOSE,
    DRAW,
    GUARD
}
//현재 스테이지의 상태를 정의하는 FSM. 싱글톤으로 저장함. 스테이지 상태에 따라 오브젝트들의 행동을 정의하기 편하기 위함.
public class StageManager : MonoBehaviour
{

    public StageState current;
    public GameObject mapCanvas;
    //스테이지 매니저 싱글톤
    public static StageManager stageSingletom;
    public GameObject WinFlashCanvas;
    public GameObject LoseFlashCanvas;
    public GameObject DrawFlashCanvas;
    public GameObject RestCanvas;
    public GameObject StoreCanvas;
    public GameObject BulletCanvas;
    public GameObject OutGameToolsCanvas;
    public GameObject LoadCanvas;
    //public GameObject CardDeck;
    public Canvas HPText;
    //public Text DeckCountText;
    public GameObject mapSelectCanvas;
    public GameObject MinimapAnchor;
    
    public Text MapselectLimitTime;
    public Text MapselectLimitTimeShadow;

    public Image StaminarSlot;

    public float SlowMotionTemp;
    public bool SlowMotionOn;

    public int KillCount;

    //public int RedAttackCurrent;
    //public int BlueAttackCurrent;
    //public int RedAttackAmount;
    //public int BlueAttackAmount;
    public GameObject aimCanvas;

    Transform[] skillSlots = new Transform[2];

    //FSM 저장부
    Dictionary<StageState, StageParent> StageFlow = new Dictionary<StageState, StageParent>();

    private void Awake()
    {
        //RedAttackCurrent = RedAttackAmount;
        //BlueAttackCurrent = BlueAttackAmount;
        if (stageSingletom == null)
            stageSingletom = this;

        SlowMotionOn = false;
        SlowMotionTemp = 0.5f;

        //미니맵 캔버스
        skillSlots[0] = GameObject.FindGameObjectWithTag("SkillSlot").transform.GetChild(0);
        skillSlots[1] = GameObject.FindGameObjectWithTag("SkillSlot").transform.GetChild(1);
        BulletCanvas = GameObject.FindGameObjectWithTag("Bullet");
        BulletCanvas.SetActive(false);
        mapCanvas = GameObject.FindGameObjectWithTag("Map");
        //CardDeck = GameObject.FindGameObjectWithTag("CardDeck").transform.GetChild(0).gameObject;
        mapSelectCanvas = GameObject.FindGameObjectWithTag("MapCards");
        MinimapAnchor = GameObject.FindGameObjectWithTag("Anchor");
        StoreCanvas = GameObject.FindGameObjectWithTag("Store");

        StageFlow.Add(StageState.READY, GetComponent<StageStart>());
        StageFlow.Add(StageState.IDLE, GetComponent<StageIDLE>());
        StageFlow.Add(StageState.MONSTERBATTLE, GetComponent<StageBattle>());
        StageFlow.Add(StageState.GAMEOVER, GetComponent<StageGameOver>());
        StageFlow.Add(StageState.MAPSELECT, GetComponent<StageSelectMap>());
        StageFlow.Add(StageState.GAMECLEAR, GetComponent<StageClear>());
        StageFlow.Add(StageState.REST, GetComponent<StageRest>());
        StageFlow.Add(StageState.WEAPONSELECT, GetComponent<StageWeaponSelect>());
        StageFlow.Add(StageState.STORE, GetComponent<StageStore>());
        StageFlow.Add(StageState.BOSSBATTLE, GetComponent<StageBoss>());
        WinFlashCanvas.SetActive(false);
        LoseFlashCanvas.SetActive(false);
        DrawFlashCanvas.SetActive(false);
        RestCanvas.SetActive(false);
        StoreCanvas.SetActive(false);
        OutGameToolsCanvas.SetActive(false);
        LoadCanvas.SetActive(false);
        current = StageState.WEAPONSELECT;
        SetState(current);
        
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        MinimapAnchor.GetComponent<RectTransform>().localPosition
            = new Vector3(-467 + (PlayerManager.playerSingleton.transform.position.x
                           - (MapPositionManager.mapMax - MapPositionManager.mapMaxCurrent)) * 950 / MapPositionManager.mapMaxCurrent, 494, 0);
        //임시로 넣어둔 esc 누를 시 게임종료하는 기능
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if((current==StageState.IDLE || current==StageState.BOSSBATTLE)&& Input.GetKeyDown(KeyCode.E))
        {
            skillSlots[0].GetChild(0).GetComponent<CardParent>().KeyBordInput();
            SkillUsed();
        }

        StaminarSlot.fillAmount = PlayerManager.playerSingleton.stam / 100;

        
    }

    private void FixedUpdate()
    {
        
        if (SlowMotionOn)
        {
            SlowMotionTemp -= Time.deltaTime;
            if(SlowMotionTemp<=0)
            {
                SlowMotionOn = false;
                Time.timeScale = 1.0f;
                CameraManager.camSingleTon.SetState(CamState.SHAKE);
            }
        }
    }

    public void SetState(StageState newst)
    {
        foreach(StageParent currentstage in StageFlow.Values)
        {
            if (currentstage.enabled == true)
                currentstage.EndState();
            currentstage.enabled = false;
        }
        current = newst;
        StageFlow[current].enabled = true;
        StageFlow[current].BeginState();
    }
    
    public void SkillAdd(GameObject newSkill)
    {
        if (skillSlots[1].childCount != 0)
        {
            GameObject destroySkill = skillSlots[1].GetChild(0).gameObject;
            destroySkill.transform.SetParent(null);
            Destroy(destroySkill);
        }
        if(skillSlots[0].childCount != 0)
        {
            skillSlots[0].GetChild(0).SetParent(skillSlots[1]);
            skillSlots[1].GetChild(0).localPosition = Vector3.zero;

            skillSlots[1].GetChild(0).localScale = new Vector3(0.8f, 0.8f, 0.8f);
        }

        newSkill.transform.SetParent(skillSlots[0]);
        newSkill.transform.localPosition = Vector3.zero;
        //newSkill.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 100);
    }

    public bool SkillGained()
    {
        if (skillSlots[0].childCount != 0)
            return true;
        else
            return false;
    }

    public void SkillUsed()
    {
        if (skillSlots[1].childCount != 0)
        {
            skillSlots[1].GetChild(0).SetParent(skillSlots[0]);
            skillSlots[0].GetChild(0).localPosition = Vector3.zero;

            skillSlots[0].GetChild(0).localScale = new Vector3(1, 1, 1);
        }
    }

    public void SlowMotionStart()
    {
        SlowMotionOn = true;
        SlowMotionTemp = 0.025f;
        Time.timeScale = 0.1f;
        
        
    }

    public void OutGameOn()
    {
        Time.timeScale = 0;
        OutGameToolsCanvas.SetActive(true);
    }
    
    public void StageLoad()
    {
        if(PlayerManager.playerSingleton.current==PlayerState.DELAY&&(current == StageState.READY || current==StageState.BOSSBATTLE))
           PlayerManager.playerSingleton.SetState(PlayerState.IDLE);
        if(current==StageState.READY)
           SetState(StageState.IDLE);
        LoadCanvas.SetActive(false);
    }
}
