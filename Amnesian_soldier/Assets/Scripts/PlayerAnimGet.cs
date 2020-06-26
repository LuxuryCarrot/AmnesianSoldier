using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimGet : MonoBehaviour
{
    public void Success()
    {
        

        GetComponent<Animator>().SetBool("Success", false);
        
    }
    public void Damaged()
    {
        GetComponent<Animator>().SetBool("Damaged", false);
        
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
    public void ASDF()
    {
        Debug.Log("asdf");
    }
}
