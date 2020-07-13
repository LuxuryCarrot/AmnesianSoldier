using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainSceneUIManager : MonoBehaviour
{
    public GameObject FadeOutImage;

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
        SceneFadeOut(2f, FadeOutImage, () => SceneManager.LoadScene(3)); ;
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
