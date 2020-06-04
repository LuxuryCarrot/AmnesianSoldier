using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    public GameObject Ground;   // N_Ground 프리팹을 넣어준다.

    private void Awake()
    {
        GroundInstantiate();    // GroundInstantiate함수 실행.
    }

    public void GroundInstantiate() 
    {
        for (int i = 0; i < 30; i++)                                                            // N_Ground발판 30개 생성
        {
            if (i == 29)                                                                        // 가장 마지막에 생성되는 N_Ground
            {
                GameObject obj = Instantiate(Ground, new Vector3(i, 0, 0), new Quaternion());   // N_Ground 발판 생성.
                obj.gameObject.tag = "LastGround";                                              // 가장 끝에 있는 N_Ground 오브젝트 이므로 LastGround태그를 붙혀준다.
            }
            else
                Instantiate(Ground, new Vector3(i, 0, 0), new Quaternion());                    // N_Ground 발판 생성.
        }
    }
}
