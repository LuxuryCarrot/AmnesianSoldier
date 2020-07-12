using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BossState
{
    IDLE=0,
    TRAPATTACK,
    CHAINATTACK,
    MONSTERSPAWN,
    STUN,
    ATTACK,
    DIE,
    WAKE,
    AWAKE
}
public class BossManager : MonoBehaviour
{
    Dictionary<BossState, BossParent> BossFlow = new Dictionary<BossState, BossParent>();
    public Animator anim;
    public BossState current;
    public GameObject AttackCanvas;
    public float hp;
    public float hpMax;
    public int attackAmount;
    public Queue<AttackType> attacktQueue = new Queue<AttackType>();

    public GameObject[] MonsterSpawnPool;

    private void Awake()
    {
        AttackCanvas = transform.GetChild(1).gameObject;
        anim = GetComponentInChildren<Animator>();
        PlayerManager.playerSingleton.boss = this;
        BossFlow.Add(BossState.IDLE, GetComponent<BossIdle>());
        BossFlow.Add(BossState.TRAPATTACK, GetComponent<BossTrapAttack>());
        BossFlow.Add(BossState.CHAINATTACK, GetComponent<BossAttack>());
        BossFlow.Add(BossState.MONSTERSPAWN, GetComponent<BossSpawnMob>());
        BossFlow.Add(BossState.STUN, GetComponent<BossSTUN>());
        BossFlow.Add(BossState.ATTACK, GetComponent<BossIdleAttack>());
        BossFlow.Add(BossState.DIE, GetComponent<BossDie>());
        BossFlow.Add(BossState.WAKE, GetComponent<BossWake>());
        BossFlow.Add(BossState.AWAKE, GetComponent<BossAwake>());
        current = BossState.AWAKE;
        SetState(current);
    }
    private void Update()
    {
        if(current!=BossState.STUN)
        transform.position
            = new Vector3(PlayerManager.playerSingleton.transform.position.x+10, 3.5f, 0);

        if(hp<=0)
        {
            StageManager.stageSingletom.SetState(StageState.GAMECLEAR);
            SetState(BossState.DIE);
        }
        if(StageManager.stageSingletom.BossCanvas.activeInHierarchy)
        StageManager.stageSingletom.BossCanvas.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>().fillAmount = hp / hpMax;
    }
    public void SetState(BossState news)
    {
        foreach(BossParent p in BossFlow.Values)
        {
            if (p.enabled)
            {
                p.EndState();
                p.enabled = false;
            }
        }
        current = news;
        BossFlow[current].enabled = true;
        BossFlow[current].BeginState();
    }
}
