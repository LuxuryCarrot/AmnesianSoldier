using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSound : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string BossAppEvent;
    FMOD.Studio.EventInstance BossApp;

    [FMODUnity.EventRef]
    public string BossDeadEvent;
    FMOD.Studio.EventInstance BossDead;

    [FMODUnity.EventRef]
    public string BossAttEvent;
    FMOD.Studio.EventInstance BossAtt;

    [FMODUnity.EventRef]
    public string BossPatPEvent;
    FMOD.Studio.EventInstance BossPatP;

    [FMODUnity.EventRef]
    public string BossPatSEvent;
    FMOD.Studio.EventInstance BossPatS;

    [FMODUnity.EventRef]
    public string BossPatTEvent;
    FMOD.Studio.EventInstance BossPatT;

    private void Update()
    {
        BossApp.setVolume(0.7f);
        BossAtt.setVolume(0.7f);
        BossDead.setVolume(0.7f);
        BossPatP.setVolume(0.7f);
        BossPatS.setVolume(0.7f);
        BossPatT.setVolume(0.7f);
    }

    public void BossAppear()
    {
        BossApp = FMODUnity.RuntimeManager.CreateInstance(BossAppEvent);
        BossApp.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        BossApp.start();
    }

    public void BossAttack()
    {
        BossAtt = FMODUnity.RuntimeManager.CreateInstance(BossAttEvent);
        BossAtt.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        BossAtt.start();
    }

    public void BossDie()
    {
        BossDead = FMODUnity.RuntimeManager.CreateInstance(BossDeadEvent);
        BossDead.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        BossDead.start();
    }

    public void BossPatternP()
    {
        BossPatP = FMODUnity.RuntimeManager.CreateInstance(BossPatPEvent);
        BossPatP.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        BossPatP.start();
    }

    public void BossPatternS()
    {
        BossPatS = FMODUnity.RuntimeManager.CreateInstance(BossPatSEvent);
        BossPatS.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        BossPatS.start();
    }

    public void BossPatternT()
    {
        BossPatT = FMODUnity.RuntimeManager.CreateInstance(BossPatTEvent);
        BossPatT.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        BossPatT.start();
    }
}
