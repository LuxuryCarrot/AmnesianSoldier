using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinSound : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string GoblinMAttEvent;
    FMOD.Studio.EventInstance GoblinMAtt;

    [FMODUnity.EventRef]
    public string GoblinBAttEvent;
    FMOD.Studio.EventInstance GoblinBAtt;

    [FMODUnity.EventRef]
    public string GoblinDeadEvent;
    FMOD.Studio.EventInstance GoblinDead;

    private void Update()
    {
        GoblinMAtt.setVolume(0.5f);
        GoblinBAtt.setVolume(0.5f);
        GoblinDead.setVolume(0.5f);
    }

    public void GoblinMeleeAttack()
    {
        GoblinMAtt = FMODUnity.RuntimeManager.CreateInstance(GoblinMAttEvent);
        GoblinMAtt.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        GoblinMAtt.start();
    }

    public void GoblinBowAttack()
    {
        GoblinBAtt = FMODUnity.RuntimeManager.CreateInstance(GoblinBAttEvent);
        GoblinBAtt.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        GoblinBAtt.start();
    }

    public void GoblinDie()
    {
        GoblinDead = FMODUnity.RuntimeManager.CreateInstance(GoblinDeadEvent);
        GoblinDead.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        GoblinDead.start();
    }
}
