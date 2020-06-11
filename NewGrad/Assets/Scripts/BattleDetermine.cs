using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//전투 결과를 판정하는 판정 함수를 넣는 클래스. 
public class BattleDetermine
{

    //방향키 방향을 바탕으로 판정 하는 함수
    public static BattleResult Determine(AttackType player, AttackType enemy)
    {
        if (player==enemy || player==AttackType.NONE)
        {
            
            return BattleResult.LOSE;
        }
        else if (player ==AttackType.GUARD)
            return BattleResult.DRAW;
        else
            return BattleResult.WIN;

    }
}
