using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testbullet : MonoBehaviour
{
    public GameObject fiewPoint;
    public List<GameObject> vfx = new List<GameObject>();

    private GameObject effectToSpawn;

    private void Start()
    {
        effectToSpawn = vfx[0];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SpawnVFX();
        }
    }

    void SpawnVFX()
    {
        GameObject vfx;

        if (fiewPoint != null)
        {
            vfx = Instantiate(effectToSpawn, fiewPoint.transform.position, Quaternion.identity);
        }
        else
        {
            Debug.Log("No Fire Point");
        }
    }
}
