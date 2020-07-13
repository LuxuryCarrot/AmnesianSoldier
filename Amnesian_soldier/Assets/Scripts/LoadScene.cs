using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    public Image Slider;

    public GameObject FadeOutImage;

    private void Start()
    {
        StartCoroutine(LoadingScene());
    }
    public IEnumerator LoadingScene()
    {
        
        AsyncOperation oper = SceneManager.LoadSceneAsync(2);
        oper.allowSceneActivation = false;
        while(!oper.isDone)
        {
            float progress = oper.progress/0.9f;
            Slider.fillAmount = progress;
            
            yield return new WaitForSeconds(2);

            SceneFadeOut(2f, FadeOutImage, () => SceneManager.LoadScene("3_InGameScene")); 
            

        }

    }

    public void SceneFadeOut(float fadeTime, GameObject Fdoutimage, System.Action nextEvent = null)
    {
        StartCoroutine(CoFadeOut(fadeTime, Fdoutimage, nextEvent));
    }

    IEnumerator CoFadeOut(float fadeTime, GameObject Fdoutimage, System.Action nextEvent = null)
    {
        Fdoutimage.SetActive(true);
        Image image = Fdoutimage.GetComponent<Image>();
        Color tempColor = image.color;

        while (tempColor.a < 1f)
        {
            tempColor.a += Time.deltaTime / fadeTime;
            image.color = tempColor;
            if (tempColor.a >= 1f)
            {
                tempColor.a = 1f;
            }
            yield return null;
        }
        image.color = tempColor;
        if (nextEvent != null)
        {
            nextEvent();
        }
    }
}
