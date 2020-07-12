using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForcedSlider : MonoBehaviour
{
    float temp;
    private void OnEnable()
    {
        temp = 2;
    }
    private void Update()
    {
        GetComponent<Image>().fillAmount = (2-temp) / 2;
        temp -= Time.deltaTime;
        if (temp <= 0)
            StageManager.stageSingletom.StageLoad();
    }
}
