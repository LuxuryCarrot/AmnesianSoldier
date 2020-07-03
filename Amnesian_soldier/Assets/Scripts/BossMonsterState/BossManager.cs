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
    public int hp;
    public int attackAmount;
    public Queue<AttackType> attacktQueue = new Queue<AttackType>();

    public GameObject[] MonsterSpawnPool;

    private void Awake()
    {
        AttackCanvas = transform.GetChild(1).gameObject;
    }
    private void Update()
    {
        transform.position 
            += PlayerManager.playerSingleton.speed 
            * PlayerManager.playerSingleton.speedIncrease * Time.deltaTime;
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
