﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticManager : MonoBehaviour
{
    public bool isTutoEnd;
    public int tutoflow;
    public static StaticManager staticInfosSingleTon;
    public bool isAttTutoEnd;
    public bool isDefTutoEnd;

    private void Awake()
    {
        if (staticInfosSingleTon == null)
        {
            staticInfosSingleTon = this;
            isTutoEnd = false;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(this.gameObject);
    }
}