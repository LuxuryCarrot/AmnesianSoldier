using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapSelectCard : MonoBehaviour, IPointerClickHandler
{
    public MapNode linkedNode;

    public void OnPointerClick(PointerEventData eventData)
    {
        linkedNode.Activate();
    }
    public void DestroyThis()
    {
        Destroy(this.gameObject);
    }
}
