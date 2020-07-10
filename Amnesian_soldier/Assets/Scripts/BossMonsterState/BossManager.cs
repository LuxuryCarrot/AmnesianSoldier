using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BossState
{
    IDLE=0,
    TRAPATTACK,
    CHAINATTACK,
    MONSTERSPAWN,
    STUN
}
public class BossManager : MonoBehaviour
{
    Dictionary<BossState, BossParent> BossFlow = new Dictionary<BossState, BossParent>();
    public Animator anim;
    public BossState current;
    public GameObject AttackCanvas;
    public float hp;
    public int attackAmount;
    public Queue<AttackType> attacktQueue = new Queue<AttackType>();

    public GameObject[] MonsterSpawnPool;

    private void Awake()
    {
        AttackCanvas = transform.GetChild(1).gameObject;

        PlayerManager.playerSingleton.boss = this;
        BossFlow.Add(BossState.IDLE, GetComponent<BossIdle>());
        BossFlow.Add(BossState.TRAPATTACK, GetComponent<BossTrapAttack>());
        BossFlow.Add(BossState.CHAINATTACK, GetComponent<BossAttack>());
        BossFlow.Add(BossState.MONSTERSPAWN, GetComponent<BossSpawnMob>());
        BossFlow.Add(BossState.STUN, GetComponent<BossSTUN>());
        current = BossState.IDLE;
        SetState(current);
    }
    private void Update()
    {
        transform.position
            = new Vector3(PlayerManager.playerSingleton.transform.position.x+7, 3.5f, 0);

        if(hp<=0)
        {
            StageManager.stageSingletom.SetState(StageState.GAMECLEAR);
            Destroy(gameObject);
        }
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
