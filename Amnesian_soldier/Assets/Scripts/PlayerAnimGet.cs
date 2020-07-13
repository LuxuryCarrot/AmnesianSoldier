using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAnimGet : MonoBehaviour
{
    public GameObject bulletPrefab;

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
        
        GetComponent<Animator>().SetBool("Damaged", false);
        GetComponent<Animator>().SetBool("PotionUse", false);
        GetComponent<Animator>().SetBool("Success", false);
        
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
    public void BulletShoot()
    {
        GameObject bullet = Instantiate(bulletPrefab);
        Debug.Log("asdf");
        bullet.transform.position = transform.parent.transform.position;
        bullet.GetComponent<BulletManager>().SetInfomation(25, 0, 0, BulletType.PLAYER, 30);
        bullet.GetComponent<BulletManager>().damage = GetComponentInParent<WeaponGun>().bulletDamage;
        


        GetComponentInParent<WeaponGun>().bulletCanUse--;
        StageManager.stageSingletom.BulletCanvas.transform.GetChild(0).GetComponent<Text>().text = GetComponentInParent<WeaponGun>().bulletCanUse.ToString();
    }
    public void SuccessShoot()
    {
        Success();
        BulletShoot();
    }
}
