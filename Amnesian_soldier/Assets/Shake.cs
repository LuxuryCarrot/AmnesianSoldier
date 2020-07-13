using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public Vector3 shakePos;

    public float StartTime;
    public float EndTime;
    float temp;
    float repeatTemp;
    bool start;
    Vector3 startPos;
    // Update is called once per frame

    private void Start()
    {
        startPos = transform.position;
        repeatTemp = (EndTime - StartTime) / 4;
    }
    void Update()
    {
        temp += Time.deltaTime;
        if(temp>=StartTime && !start)
        {
            start = true;
            transform.position += startPos * 2.5f;
            return;
        }
        if(start && temp>=repeatTemp)
        {
            temp = 0;
            transform.position += startPos;
            
        }
    }
}
