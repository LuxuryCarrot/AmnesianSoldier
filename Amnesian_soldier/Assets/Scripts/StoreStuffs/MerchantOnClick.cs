using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MerchantOnClick : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 1000, 512 ))
            {
                StageManager.stageSingletom.StoreCanvas.transform.GetChild(0).gameObject.SetActive(true);
            }
        }
    }


}
