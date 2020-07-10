using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    public Image Slider;
    private void Start()
    {
        StartCoroutine(LoadingScene());
    }
    IEnumerator LoadingScene()
    {
        
        AsyncOperation oper = SceneManager.LoadSceneAsync(2);
        while(!oper.isDone)
        {
            float progress = oper.progress/0.9f;
            Slider.fillAmount = progress;
            
            yield return null;
        }
        

    }
}
