using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string PlayerAttEvent;
    FMOD.Studio.EventInstance PlayerAtt;

    [FMODUnity.EventRef]
    public string PlayerDmgEvent;
    FMOD.Studio.EventInstance PlayerDmg;

    [FMODUnity.EventRef]
    public string PlayerPotEvent;
    FMOD.Studio.EventInstance PlayerPot;

    [FMODUnity.EventRef]
    public string PlayerRunEvent;
    FMOD.Studio.EventInstance PlayerRun;

    private void Update()
    {
        PlayerAtt.setVolume(0.4f);
        PlayerRun.setVolume(0.3f);
    }

    public void PlayerAttack()
    {
        PlayerAtt = FMODUnity.RuntimeManager.CreateInstance(PlayerAttEvent);
        PlayerAtt.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        PlayerAtt.start();
    }

    public void PlayerDamage()
    {
        PlayerDmg = FMODUnity.RuntimeManager.CreateInstance(PlayerDmgEvent);
        PlayerDmg.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        PlayerDmg.start();
    }

    public void PlayerRunSound()
    {
        PlayerRun = FMODUnity.RuntimeManager.CreateInstance(PlayerRunEvent);
        PlayerRun.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        PlayerRun.start();
    }

    public void PlayerPotion()
    {
        PlayerPot = FMODUnity.RuntimeManager.CreateInstance(PlayerPotEvent);
        PlayerPot.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        PlayerPot.start();
    }
}
