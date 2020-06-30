using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CamState
{
    IDLE,
    SHAKE
}

public class CameraManager : MonoBehaviour
{
    Dictionary<CamState, CamParent> CamEffects = new Dictionary<CamState, CamParent>();
    public CamState current;
    public static CameraManager camSingleTon;

    private void Awake()
    {
        if (camSingleTon == null)
            camSingleTon = this;

        current = CamState.IDLE;
        CamEffects.Add(CamState.IDLE, GetComponent<CamIdel>());
        CamEffects.Add(CamState.SHAKE, GetComponent<CamShake>());
        SetState(current);
    }

    public void SetState(CamState news)
    {
        foreach(CamParent cams in CamEffects.Values)
        {
            if (cams.enabled)
            {
                
                cams.EndState();
                cams.enabled = false;
            }
        }
        current = news;
        CamEffects[news].enabled = true;
        CamEffects[news].BeginState();
    }
}
