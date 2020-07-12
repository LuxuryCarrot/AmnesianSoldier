using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneUIManager : MonoBehaviour
{
    float temp;
    private void Awake()
    {
        temp = 1;
    }
    private void Update()
    {
        if (temp > 0)
        {
            temp -= Time.deltaTime;
            return;
        }
        if (Input.anyKeyDown)
            NewGamePressed();
    }
    public void NewGamePressed()
    {
        SceneManager.LoadScene(3);
    }
}
