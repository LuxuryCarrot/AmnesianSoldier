using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelect : MonoBehaviour
{
    public void SwordSelect()
    {

        StageManager.stageSingletom.SetState(StageState.READY);
        this.gameObject.SetActive(false);
    }
}
