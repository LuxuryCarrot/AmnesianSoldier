using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSound : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string SlimeAttEvent;
    FMOD.Studio.EventInstance SlimeAtt;

    [FMODUnity.EventRef]
    public string SlimeDeadEvent;
    FMOD.Studio.EventInstance SlimeDead;

    private void Update()
    {
        SlimeDead.setVolume(0.5f);
    }

    public void SlimeAttack()
    {
        SlimeAtt = FMODUnity.RuntimeManager.CreateInstance(SlimeAttEvent);
        SlimeAtt.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        SlimeAtt.start();
    }

    public void SlimeDie()
    {
        SlimeDead = FMODUnity.RuntimeManager.CreateInstance(SlimeDeadEvent);
        SlimeDead.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        SlimeDead.start();
    }
}
