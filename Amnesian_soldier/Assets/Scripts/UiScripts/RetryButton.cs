using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RetryButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Sprite OnSprite;
    public Sprite offSprite;

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<Image>().sprite = OnSprite;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Image>().sprite = offSprite;
    }

    public void RetryButtonOn()
    {
        StageManager.stageSingletom = null;
        SceneManager.LoadScene(3);
    }
}
