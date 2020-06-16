using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimGet : MonoBehaviour
{
    public void Success()
    {
        //Time.timeScale = PlayerManager.playerSingleton.timeScale;
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
        PlayerManager.playerSingleton.anim.SetInteger("AttackType", 5);
        GetComponent<Animator>().SetBool("Damaged", false);
        GetComponent<Animator>().SetBool("PotionUse", false);
        GetComponent<Animator>().SetBool("Success", false);
        GetComponent<Animator>().SetBool("Cancel", false);
        GetComponent<Animator>().SetBool("Die", false);
    }
    public void Cancel()
    {
        GetComponent<Animator>().SetBool("Cancel", false);
        PlayerManager.playerSingleton.anim.SetInteger("AttackType", 5);
    }
}
