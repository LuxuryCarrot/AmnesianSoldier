using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundProperty : MonoBehaviour
{
    public GameObject Enemy;
    public float speed; // 오브젝트의 속도를 조절해주는 값.

    private void Update()
    {
        transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * speed);                                                    // Resource/Prefabs폴더의 N_Ground로 이동하여 인스펙터 창에서 speed값을 바꿔주면 땅이 움직이는 속도에 변화를 줄 수 있음.
        if (transform.position.y < -15.0f)                                                                                      // 오브젝트의 위치값이 N이하로 떨어졌을 경우 아래 코드들을 실행 시킨다.
        {
            Enemy.SetActive(false);
            GameObject LastGroundObj = GameObject.FindGameObjectWithTag("LastGround");                                          // LastGround 태그가 붙어있는 제일 뒤쪽의 그라운드 오브젝트를 받아온다.
            Transform LastGroundPos = LastGroundObj.transform;                                                                  // LastGround의 현재 포지션 값을 받아온다.
            LastGroundObj.gameObject.tag = "N_Ground";                                                                          // 현재 오브젝트가 밑으로 떨어지고 뒤로 가게 된다면 LastGround가 되기에 현재 LastGround오브젝트를 평번한 N_Ground태그가 달린 오브젝트로 바꿔준다.
            gameObject.tag = "LastGround";                                                                                      // 현재 오브젝트가 맨 뒤로 가게 되므로 현재 오브젝트의 태그를 LastGround로 바꿔준다.
            transform.SetPositionAndRotation(new Vector3(LastGroundPos.position.x + 0.9f, 0, 0), new Quaternion(0, 0, 0, 0));   // 오브젝트의 위치 값을 아까 저장했던 LastGround의 위치 바로 옆으로 옮겨준다.
            isKinematicSet();                                                                                                   // 떨어지며 꺼졌던 리지드 바디의 Kinematic을 켜준다.
            RandomSpawnEnemy();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))          // 이 오브젝트에 Player태그가 달린 오브젝트가 충돌 했는지 안했는지를 판별해줌.
        {
            Invoke("isKinematicSet", 1.0f);                     // 이 오브젝트가 Player와 충돌하였으므로 리지드 바디의 Kinematic을 꺼줌으로써 오브젝트가 추락하게 됨.
        }
    }

    private void isKinematicSet()                               // 이 함수를 호출했을때의 isKinematic기능이 꺼져있으면 켜주고, 켜져있으면 꺼주는 함수이다.
    {
        Rigidbody rigi = gameObject.GetComponent<Rigidbody>();  // 현재 오브젝트의 rigidbody 기능을 받아옴.
        if (rigi.isKinematic)                                   // Kinematic기능이 켜져있다면
            rigi.isKinematic = false;                           // Kinematic기능을 꺼줘라.
        else                                                    // Kinematic기능이 켜져있지 않다면.
            rigi.isKinematic = true;                            // Kinematic기능을 켜줘라.
    }

    private void RandomSpawnEnemy()
    {
        int i = Random.Range(0, 100);
        int m = Random.Range(0, 3);

        if (i < 15)
        {
            Enemy.SetActive(true);
        }


    }


}
