using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkingEffects : MonoBehaviour
{
    float temp = 0.05f;
    float repeat = 4;

    // Update is called once per frame
    void Update()
    {
        temp -= Time.deltaTime;
        if(repeat>=0&& temp <=0)
        {
            repeat--;
            temp = 0.1f;
            GetComponent<Image>().enabled = GetComponent<Image>().enabled ? false : true;
        }
        if (repeat < 0)
            Destroy(gameObject);
    }
}
