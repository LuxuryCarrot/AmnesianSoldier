using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneUIManager : MonoBehaviour
{
    public void NewGamePressed()
    {
        SceneManager.LoadScene(3);
    }
}
