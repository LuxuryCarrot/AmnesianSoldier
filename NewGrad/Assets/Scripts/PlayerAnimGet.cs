﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimGet : MonoBehaviour
{
    public void Success()
    {
        GetComponent<Animator>().SetBool("Success", false);
        PlayerManager.playerSingleton.anim.SetInteger("AttackType", 5);
    }
    public void Damaged()
    {
        GetComponent<Animator>().SetBool("Damaged", false);
        PlayerManager.playerSingleton.anim.SetInteger("AttackType", 5);
    }
    public void PotionUse()
    {
        GetComponent<Animator>().SetBool("PotionUse", false);
    }
    public void Die()
    {
        GetComponent<Animator>().SetBool("Die", false);
    }
    public void Cancel()
    {
        GetComponent<Animator>().SetBool("Cancel", false);
        PlayerManager.playerSingleton.anim.SetInteger("AttackType", 5);
    }
}