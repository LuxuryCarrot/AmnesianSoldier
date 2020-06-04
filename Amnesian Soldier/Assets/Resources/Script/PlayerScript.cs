using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public Text CurHP;

    private int HP;

    private void Awake()
    {
        HP = 3;
    }

    private void Update()
    {
        CurHP.text = "HP : " + HP;
    }
}
