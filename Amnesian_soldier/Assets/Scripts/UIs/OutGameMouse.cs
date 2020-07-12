using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OutGameMouse : MonoBehaviour, IPointerEnterHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {

        transform.GetChild(0).gameObject.SetActive(true);
        for(int i=0;i< transform.parent.childCount; i++)
        {
            Transform looking = transform.parent.GetChild(i);
            if (looking != transform)
                looking.GetChild(0).gameObject.SetActive(false);
        }
    }
}
