using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FmodController : MonoBehaviour
{
    public void PlayerRunSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/PC/Run/Dirt");
    }

    public void PlayerAttack()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/PC/Attack/Sword/BAttack");
    }

    public void PlayerPotion()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/PC/Use/HPPotion");
    }

    public void PlayerDamaged()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/PC/Damaged/Damaged");
    }

    public void PlayerDSword()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/PC/Attack/Sword/DSword");
    }

    public void SlimeAttack()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Enemy/Slime/Attack");
    }


    public void SlimeDie()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Enemy/Slime/Die");
    }

    //[FMODUnity.EventRef]
    //public string SlimeDieEvent;
    //FMOD.Studio.EventInstance SlimeDieT;

    //public void Ddd()
    //{
    //    SlimeDieT = FMODUnity.RuntimeManager.CreateInstance(SlimeDieEvent);
    //    SlimeDieT.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
    //    SlimeDieT.start();
    //    print("SlimeDIe");
    //}


}
