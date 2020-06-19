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
    WEAPONSELECT
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
    public GameObject CardDeck;
    public Canvas HPText;
    public Text DeckCountText;
    public GameObject mapSelectCanvas;
    public GameObject MinimapAnchor;
    
    public Text MapselectLimitTime;
    public Text MapselectLimitTimeShadow;
    //public GameObject aimCanvas;

    //FSM 저장부
    Dictionary<StageState, StageParent> StageFlow = new Dictionary<StageState, StageParent>();

    private void Awake()
    {
        if (stageSingletom == null)
            stageSingletom = this;

        //미니맵 캔버스
        mapCanvas = GameObject.FindGameObjectWithTag("Map");
        CardDeck = GameObject.FindGameObjectWithTag("CardDeck").transform.GetChild(0).gameObject;
        mapSelectCanvas = GameObject.FindGameObjectWithTag("MapCards");
        MinimapAnchor = GameObject.FindGameObjectWithTag("Anchor");

        StageFlow.Add(StageState.READY, GetComponent<StageStart>());
        StageFlow.Add(StageState.IDLE, GetComponent<StageIDLE>());
        StageFlow.Add(StageState.MONSTERBATTLE, GetComponent<StageBattle>());
        StageFlow.Add(StageState.GAMEOVER, GetComponent<StageGameOver>());
        StageFlow.Add(StageState.MAPSELECT, GetComponent<StageSelectMap>());
        StageFlow.Add(StageState.GAMECLEAR, GetComponent<StageClear>());
        StageFlow.Add(StageState.REST, GetComponent<StageRest>());
        StageFlow.Add(StageState.WEAPONSELECT, GetComponent<StageWeaponSelect>());
        WinFlashCanvas.SetActive(false);
        LoseFlashCanvas.SetActive(false);
        DrawFlashCanvas.SetActive(false);
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

}
