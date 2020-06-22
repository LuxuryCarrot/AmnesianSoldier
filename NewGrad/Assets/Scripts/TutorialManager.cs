using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public static bool tutorialEnded=false;
    public GameObject tutorialCanvas1;
    public GameObject tutorialCanvas2;
    public GameObject tutorialCanvas3;
    public GameObject tutorialCanvas4;
    public GameObject tutorialCanvas5;
    public float temp;
    public int num=0;

    private void Awake()
    {
        tutorialCanvas1.SetActive(false);
        tutorialCanvas2.SetActive(false);
        tutorialCanvas3.SetActive(false);
        tutorialCanvas4.SetActive(false);
        tutorialCanvas5.SetActive(false);
    }
    
    private void Update()
    {
        
        if(!tutorialEnded)
        {
            if(num ==0 && MonsterManager.Monsters[0].transform.position.x - PlayerManager.playerSingleton.transform.position.x <= 7)
            {
                Time.timeScale = 0.01f;
                tutorialCanvas1.SetActive(true);
                temp += Time.fixedDeltaTime;
                Debug.Log(0);
                if(temp >=3)
                {
                    temp = 0;
                    num++;
                    tutorialCanvas1.SetActive(false);
                }
            }
            else if(num==1)
            {
                tutorialCanvas2.SetActive(true);
                temp += Time.fixedDeltaTime;
                if (temp >= 3)
                {
                    temp = 0;
                    num++;
                    tutorialCanvas2.SetActive(false);
                    //Time.timeScale = 1;
                }
            }
            else if(num == 2)
            {
                tutorialCanvas5.SetActive(true);
                temp += Time.fixedDeltaTime;
                if (temp >= 3)
                {
                    temp = 0;
                    num++;
                    tutorialCanvas5.SetActive(false);
                    Time.timeScale = 1;
                }
            }
            else if(num==3 && MonsterManager.Monsters[0].transform.position.x- PlayerManager.playerSingleton.transform.position.x <= PlayerManager.playerSingleton.AimStartRange+0.5f)
            {
                tutorialCanvas3.SetActive(true);
                Time.timeScale = 0.01f;
                if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2))
                {
                    
                    num++;
                    tutorialCanvas3.SetActive(false);
                    Time.timeScale = 1;
                }
            }
            else if(num ==4)
            {
                tutorialCanvas4.SetActive(true);
                temp += Time.fixedDeltaTime;
                if(temp >=3)
                {
                    num++;
                    tutorialCanvas4.SetActive(false);
                    tutorialEnded = true;
                }
            }
        }
    }
}
