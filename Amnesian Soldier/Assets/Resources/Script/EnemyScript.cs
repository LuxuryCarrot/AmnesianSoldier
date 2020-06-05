using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject AttackingObj;

    public Sprite ArrowSprite;

    private Sprite AttackSprite;

    private void Awake()
    {
        AttackSprite = AttackingObj.GetComponent<Sprite>();
    }

    private void Update()
    {
        AttackSprite = ArrowSprite;
    }
}
