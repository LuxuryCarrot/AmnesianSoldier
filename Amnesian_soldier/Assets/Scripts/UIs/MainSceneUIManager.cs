using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneUIManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.anyKeyDown)
            NewGamePressed();
    }
    public void NewGamePressed()
    {
        SceneManager.LoadScene(3);
    }
}
