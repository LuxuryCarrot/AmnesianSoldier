using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamParent : MonoBehaviour
{
    public CameraManager manager;
    private void Awake()
    {
        manager = GetComponent<CameraManager>();
    }
    public virtual void BeginState()
    {

    }
    public virtual void EndState()
    {

    }
}
