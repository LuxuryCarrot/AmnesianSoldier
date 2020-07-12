using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonParent : MonoBehaviour, IPointerClickHandler
{
    public virtual void Execute() { }
    public void OnPointerClick(PointerEventData eventData)
    {
        Execute();
    }
}
