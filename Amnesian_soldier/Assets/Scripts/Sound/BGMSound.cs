using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMSound : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string RunBGMIntroEvent;
    FMOD.Studio.EventInstance RunBGMIntro;

    [FMODUnity.EventRef]
    public string RunBGMLoopEvent;
    FMOD.Studio.EventInstance RunBGMLoop;

    private void Awake()
    {
        RunBGMIntro = FMODUnity.RuntimeManager.CreateInstance(RunBGMIntroEvent);
        RunBGMLoop = FMODUnity.RuntimeManager.CreateInstance(RunBGMLoopEvent);

        StartCoroutine("PlayInGameBGM_intro");
    }

    private void FixedUpdate()
    {
        RunBGMIntro.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        RunBGMLoop.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));


        RunBGMIntro.setVolume(0.1f);
        RunBGMLoop.setVolume(0.1f);
    }


    IEnumerator PlayInGameBGM_intro()
    {
        RunBGMIntro.start();

        yield return new WaitForSecondsRealtime(16.5f);

        StartCoroutine("PlayInGameBGM");
        StopCoroutine("PlayInGameBGM_intro");
    }

    IEnumerator PlayInGameBGM()
    {
        RunBGMLoop.start();

        yield return new WaitForSecondsRealtime(40.0f);

        StartCoroutine("PlayInGameBGM_loop");
        StopCoroutine("PlayInGameBGM");
    }

    IEnumerator PlayInGameBGM_loop()
    {
        RunBGMLoop.start();

        yield return new WaitForSecondsRealtime(40.0f);

        StartCoroutine("PlayInGameBGM_loop");
    }
}
