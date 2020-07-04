﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapSelectCard : MonoBehaviour
{
    public MapNode linkedNode;

    public void OnPointerClick()
    {
        MonsterManager.Monsters.Clear();
        linkedNode.Activate();
    }
    public void DestroyThis()
    {
        transform.parent.SetParent(null);
        Destroy(transform.parent.gameObject);
    }
}
