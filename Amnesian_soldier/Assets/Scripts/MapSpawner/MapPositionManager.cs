using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//맵의 위치와 크기를 저장하는 스태틱 클래스
public class MapPositionManager : MonoBehaviour
{
    public static int mapPos;
    public static int mapMax;
    public static GameObject field;
    public static int mapNum;
    public static int mapMaxCurrent;
    public static int mapDontCmaChase;
    
    private void Awake()
    {
        mapPos = 0;
        mapMax = 0;
        
        if(field==null)
        {
            field = this.gameObject;
        }
    }
}
