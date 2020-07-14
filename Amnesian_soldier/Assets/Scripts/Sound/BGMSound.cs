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

    [FMODUnity.EventRef]
    public string BossBGMIntroEvent;
    FMOD.Studio.EventInstance BossBGMIntro;

    [FMODUnity.EventRef]
    public string BossBGMLoopEvent;
    FMOD.Studio.EventInstance BossBGMLoop;

    public static BGMSound instance;

    public bool isboss = false;
    private bool once = true;

    private void Awake()
    {
        instance = this;
        RunBGMIntro = FMODUnity.RuntimeManager.CreateInstance(RunBGMIntroEvent);
        RunBGMLoop = FMODUnity.RuntimeManager.CreateInstance(RunBGMLoopEvent);
        BossBGMIntro = FMODUnity.RuntimeManager.CreateInstance(BossBGMIntroEvent);
        BossBGMLoop = FMODUnity.RuntimeManager.CreateInstance(BossBGMLoopEvent);

        StartCoroutine("PlayInGameBGM_intro");
    }

    private void FixedUpdate()
    {
        RunBGMIntro.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        RunBGMLoop.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        BossBGMIntro.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        BossBGMLoop.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));


        RunBGMIntro.setVolume(0.1f);
        RunBGMLoop.setVolume(0.1f);
        BossBGMIntro.setVolume(0.1f);
        BossBGMLoop.setVolume(0.1f);
    }

    private void Update()
    {
        if (isboss && once)
        {
            Debug.Log("im in bossroom");
            StopCoroutine("PlayInGameBGM_loop");
            RunBGMLoop.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            StartCoroutine("PlayBossBGM_intro");
            once = false;
        }
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

    IEnumerator PlayBossBGM_intro()
    {
        BossBGMIntro.start();

        yield return new WaitForSecondsRealtime(11.675f);

        StartCoroutine("PlayBossBGM");
        StopCoroutine("PlayBossBGM_intro");
    }

    IEnumerator PlayBossBGM()
    {
        BossBGMLoop.start();

        yield return new WaitForSecondsRealtime(51.523f);

        StartCoroutine("PlayBossBGM_loop");
        StopCoroutine("PlayBossBGM");
    }

    IEnumerator PlayBossBGM_loop()
    {
        BossBGMLoop.start();

        yield return new WaitForSecondsRealtime(51.523f);

        StartCoroutine("PlayBossBGM_loop");
    }
}
