using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//플레이어 상태를 정의하는 부모 클래스
public class PlayerParent : MonoBehaviour
{
    public PlayerManager manager;

    private void Awake()
    {
        manager = GetComponent<PlayerManager>();
    }
    public virtual void BeginState()
    {

    }
    public virtual void EndState()
    {

    }
}
