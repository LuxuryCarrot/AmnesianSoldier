using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHaist : CardParent
{
    public override void KeyBordInput()
    {
        transform.SetParent(null);

        PlayerManager.playerSingleton.burftemp = 5;
        PlayerManager.playerSingleton.speedIncrease = 1.5f;
        StageManager.stageSingletom.SkillUsed();
        Destroy(this.gameObject);
    }
}
