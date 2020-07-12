using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelect : MonoBehaviour
{
    public void SwordSelect()
    {
        GameObject sword = Instantiate(
            Resources.Load("Prefabs/Player/PlayerSword") as GameObject, PlayerManager.playerSingleton.transform);
        PlayerManager.playerSingleton.anim = sword.GetComponent<Animator>();
        PlayerManager.playerSingleton.gameObject.AddComponent<WeaponSword>();
        PlayerManager.playerSingleton.weapon = PlayerManager.playerSingleton.GetComponent<WeaponParent>();
        StageManager.stageSingletom.SetState(StageState.IDLE);
        PlayerManager.playerSingleton.SetState(PlayerState.IDLE);
        this.gameObject.SetActive(false);
    }
    public void GunSelect()
    {
        GameObject gun = Instantiate(
            Resources.Load("Prefabs/Player/PlayerGun") as GameObject, PlayerManager.playerSingleton.transform);
        PlayerManager.playerSingleton.anim = gun.GetComponent<Animator>();
        PlayerManager.playerSingleton.gameObject.AddComponent<WeaponGun>();
        PlayerManager.playerSingleton.weapon = PlayerManager.playerSingleton.GetComponent<WeaponParent>();
        StageManager.stageSingletom.SetState(StageState.IDLE);
        PlayerManager.playerSingleton.SetState(PlayerState.IDLE);
        this.gameObject.SetActive(false);
    }
}
