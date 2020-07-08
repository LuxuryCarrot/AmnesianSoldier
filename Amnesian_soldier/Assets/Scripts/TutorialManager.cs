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
    public GameObject tutorialCanvas6;
    public float temp;
    public int num=0;
    bool att = false;
    bool def = false;

    private void Awake()
    {
        tutorialCanvas1.SetActive(false);
        tutorialCanvas2.SetActive(false);
        tutorialCanvas3.SetActive(false);
        tutorialCanvas4.SetActive(false);
        tutorialCanvas5.SetActive(false);
        tutorialCanvas6.SetActive(false);
        gameObject.SetActive(false);
    }
    
    private void Update()
    {
        
        if(!tutorialEnded && MonsterManager.Monsters.Count!=0)
        {
            if(num ==0 && MonsterManager.Monsters[0].transform.position.x - PlayerManager.playerSingleton.transform.position.x <= 7)
            {
                Time.timeScale = 0.01f;
                tutorialCanvas1.SetActive(true);
                temp += Time.fixedDeltaTime;
                
                if(temp >=1.5f)
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
                if (temp >= 1.5f)
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
                if (temp >= 1.5f)
                {
                    temp = 0;
                    num++;
                    tutorialCanvas5.SetActive(false);
                    Time.timeScale = 1;
                }
            }
            else if(!att && num==3
                && MonsterManager.Monsters[0].transform.position.x- PlayerManager.playerSingleton.transform.position.x <= 7
                && MonsterManager.Monsters[0].GetComponent<EnemyManager>().attackType==AttackType.HORIZON)
            {
                tutorialCanvas3.SetActive(true);
                Time.timeScale = 0.01f;
                if (Input.GetMouseButtonDown(1) || MonsterManager.Monsters[0].GetComponent<EnemyManager>().attackType==AttackType.NONE )
                {
                    
                    att = true;
                    if (att && def)
                        num++;
                    tutorialCanvas3.SetActive(false);
                    Time.timeScale = 1;
                }
            }
            else if (!def && num == 3 && MonsterManager.Monsters[0].transform.position.x - PlayerManager.playerSingleton.transform.position.x <= 7
                && MonsterManager.Monsters[0].GetComponent<EnemyManager>().attackType == AttackType.GUARD)
            {
                tutorialCanvas6.SetActive(true);
                Time.timeScale = 0.01f;
                if (Input.GetMouseButtonDown(1))
                {
                    
                    def = true;
                    if(att && def)
                      num++;
                    tutorialCanvas6.SetActive(false);
                    Time.timeScale = 1;
                }
            }
            else if(num ==5 && StageManager.stageSingletom.SkillGained())
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
