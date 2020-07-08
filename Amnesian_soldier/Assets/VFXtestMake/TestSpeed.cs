using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpeed : MonoBehaviour
{
    public float angle = 45; // 각도
    public float powerY = 40; // Y축으로의 힘, 중력의 영향을 받음
    public float powerX = 40; // X축으로의 힘, 중력의 영향을 받지 않음
    public float GP = 20; // 중력

    float vx; // x 이동값
    float vy; // y 이동값

    float timer; // 일정 시간이 지난 후 이 오브젝트를 삭제 하기 위한 시간 측정 변수
    public float endTime = 5.0f; // 얼마만큼의 시간이 흐른 후 삭제 할 것인지를 정하기 위한 변수.

    public float fireRate;
    public GameObject muzzlePrefab;
    public GameObject hitPrefab;

    private void Start()
    {
        if (muzzlePrefab != null)
        {
            var muzzleVFX = Instantiate(muzzlePrefab, transform.position, Quaternion.identity);
            muzzleVFX.transform.forward = gameObject.transform.forward;
            var psMuzzel = muzzleVFX.GetComponent<ParticleSystem>();
            if (psMuzzel != null)
            {
                Destroy(muzzleVFX, psMuzzel.main.duration);
            }
            else{
                var psChild = muzzleVFX.transform.GetChild(0).GetComponent<ParticleSystem>();
                Destroy(muzzleVFX, psChild.main.duration);
            }
        }
    }

    void Update()
    {
        vx = powerX * Mathf.Cos(Mathf.Deg2Rad * angle) * Time.deltaTime;
        vy = powerY * Mathf.Sin(Mathf.Deg2Rad * angle) * Time.deltaTime;

        powerY -= GP * Time.deltaTime;

        transform.position = new Vector2(transform.position.x + vx, transform.position.y + vy);

        timer += Time.deltaTime;

        if (timer >= endTime)
        {
            Destroy(gameObject);
        }

    }


    private void OnCollisionEnter(Collision collision)
    {
        powerY = 0;

        ContactPoint contact = collision.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;

        if (hitPrefab != null)
        {
            var hitVFX = Instantiate(hitPrefab, pos, rot);
            var psHit = hitVFX.GetComponent<ParticleSystem>();
            if (psHit != null)
            {
                Destroy(hitVFX, psHit.main.duration);
            }
            else
            {
                var psChild = hitVFX.transform.GetChild(0).GetComponent<ParticleSystem>();
                Destroy(hitVFX, psChild.main.duration);
            }
        }

        Destroy(gameObject);
    }

    //
    // 총알 생성 코드 
    //
    public void SetBullet(float _power, float _angle, float _GravityPower)
    {
        powerY = _power;
        powerX = _power;

        angle = _angle;

        GP = _GravityPower;
    }
}
