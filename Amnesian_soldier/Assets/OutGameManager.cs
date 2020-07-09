using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutGameManager : MonoBehaviour
{
    public int enabledButton;


    private void OnEnable()
    {
        enabledButton = 0;
        transform.GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(true);
        transform.GetChild(0).GetChild(1).GetChild(0).gameObject.SetActive(false);
        transform.GetChild(0).GetChild(2).GetChild(0).gameObject.SetActive(false);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (enabledButton == 2)
                return;

            enabledButton++;
            transform.GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(false);
            transform.GetChild(0).GetChild(1).GetChild(0).gameObject.SetActive(false);
            transform.GetChild(0).GetChild(2).GetChild(0).gameObject.SetActive(false);

            transform.GetChild(0).GetChild(enabledButton).GetChild(0).gameObject.SetActive(true);
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (enabledButton == 0)
                return;
            enabledButton--;

            transform.GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(false);
            transform.GetChild(0).GetChild(1).GetChild(0).gameObject.SetActive(false);
            transform.GetChild(0).GetChild(2).GetChild(0).gameObject.SetActive(false);

            transform.GetChild(0).GetChild(enabledButton).GetChild(0).gameObject.SetActive(true);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            transform.GetChild(0).GetChild(enabledButton).GetChild(0).GetComponent<ButtonParent>().Execute();
        }
    }
}
