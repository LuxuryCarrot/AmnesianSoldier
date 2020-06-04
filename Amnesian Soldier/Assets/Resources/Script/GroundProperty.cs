using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundProperty : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("GroundFall", 2.0f);
        }
    }

    private void GroundFall()
    {
        Rigidbody rigi = gameObject.GetComponent<Rigidbody>();

        rigi.isKinematic = false;
    }
}
