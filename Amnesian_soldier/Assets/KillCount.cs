using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillCount : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = StageManager.stageSingletom.KillCount.ToString();
    }
}
