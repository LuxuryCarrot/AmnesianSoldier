using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnionSound : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string OnionAppEvent;
    FMOD.Studio.EventInstance OnionApp;

    [FMODUnity.EventRef]
    public string OnionAttEvent;
    FMOD.Studio.EventInstance OnionAtt;

    [FMODUnity.EventRef]
    public string OnionDeadEvent;
    FMOD.Studio.EventInstance OnionDead;

    private void Update()
    {
        OnionApp.setVolume(0.5f);
        OnionAtt.setVolume(0.5f);
        OnionDead.setVolume(0.5f);
    }

    public void OnionAttack()
    {
        OnionAtt = FMODUnity.RuntimeManager.CreateInstance(OnionAttEvent);
        OnionAtt.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        OnionAtt.start();
    }

    public void OnionAppear()
    {
        OnionApp = FMODUnity.RuntimeManager.CreateInstance(OnionAppEvent);
        OnionApp.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        OnionApp.start();
    }

    public void OnionDie()
    {
        OnionDead = FMODUnity.RuntimeManager.CreateInstance(OnionDeadEvent);
        OnionDead.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        OnionDead.start();
    }
}
