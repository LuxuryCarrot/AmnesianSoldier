using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public int tutoFlow;
    public int skillFlow;

    public bool isAttTutoEnd;
    public bool isDefTutoEnd;

    public bool isAttackWhenAtt;
    public bool isAttackWhenDef;

    float temp;

    public GameObject Tuto1;
    public GameObject Tuto2;
    public GameObject Tuto3;
    public GameObject Tuto4;
    public GameObject Tuto5;
    public GameObject Tuto6;
    public GameObject Tuto7;
    public GameObject Tuto8;
    public GameObject Tuto9;
    public GameObject Tuto10;
    public GameObject Tuto11;
    public GameObject Tuto12;
    public GameObject Tuto13;
    public GameObject Tuto14;
    public GameObject Tuto15;
    public GameObject Tuto16;
    public GameObject Tuto17;
    public GameObject Tuto18;
    public GameObject Tuto19;
    public GameObject Tuto20;
    public GameObject Tuto21;
    public GameObject Tuto22;
    public GameObject Tuto23;
    public GameObject Tuto24;
    public GameObject TutoRetry;

    float skillTemp;
    float attTemp;
    int attTuto = 0;
    int defTuto = 0;

    private void Awake()
    {
        tutoFlow = 0;
        skillFlow = 0;
        temp = 2;
        skillTemp = 2;
        attTemp = 2;
        attTuto = 0;
        defTuto = 0;
    }
    private void Start()
    {
        tutoFlow = StaticManager.staticInfosSingleTon.tutoflow;
    }
    private void Update()
    {
        if (StaticManager.staticInfosSingleTon.isTutoEnd)
            return;

        StaticManager.staticInfosSingleTon.tutoflow = tutoFlow;

        if (PlayerManager.playerSingleton == null)
            return;
        if (Camera.main.transform.parent == PlayerManager.playerSingleton.transform && tutoFlow==0)
            tutoFlow++;
        if (tutoFlow == 1)
        {
            Tuto1.SetActive(true);
            Time.timeScale = 0.01f;
            temp -= Time.fixedDeltaTime;
            if (temp <= 0)
            {
                Time.timeScale = 1;
                temp = 2;
                tutoFlow++;
                Tuto1.SetActive(false);
            }
        }
        else if (tutoFlow == 2)
        {
            Tuto2.SetActive(true);
            Time.timeScale = 0.01f;
            temp -= Time.fixedDeltaTime;
            if (temp <= 0)
            {
                Time.timeScale = 1;
                temp = 2;
                tutoFlow++;
                Tuto2.SetActive(false);
            }

        }
        else if (tutoFlow == 3)
        {
            Tuto3.SetActive(true);
            Time.timeScale = 0.01f;
            temp -= Time.fixedDeltaTime;
            if (temp <= 0)
            {
                Time.timeScale = 1;
                temp = 2;
                tutoFlow++;
                Tuto3.SetActive(false);
            }
        }
        else if (tutoFlow == 4 && PlayerManager.playerSingleton.iteratingEnemy != null &&
             PlayerManager.playerSingleton.iteratingEnemy.transform.position.x - PlayerManager.playerSingleton.transform.position.x <=6)
        {
            Tuto4.SetActive(true);
            Time.timeScale = 0.01f;
            temp -= Time.fixedDeltaTime;
            if (temp <= 0)
            {
                Time.timeScale = 1;
                temp = 2;
                tutoFlow++;
                Tuto4.SetActive(false);
            }
        }
        else if (tutoFlow == 5 && (isAttackWhenAtt || isAttackWhenDef ))
        {
            tutoFlow += 2;
        }
        else if (tutoFlow == 7 && PlayerManager.playerSingleton.iteratingEnemy!=null &&
            PlayerManager.playerSingleton.iteratingEnemy.attackType==AttackType.NONE)
        {
            Tuto7.SetActive(true);
            Time.timeScale = 0.01f;
            
            if (Input.GetMouseButtonDown(0))
            {
                Time.timeScale = 1;
                temp = 2;
                tutoFlow++;
                Tuto7.SetActive(false);
            }
        }
        else if (tutoFlow == 8)
        {
            Tuto8.SetActive(true);
            
            temp -= Time.fixedDeltaTime;
            if (temp <= 0)
            {
                temp = 2;
                tutoFlow++;
                Tuto8.SetActive(false);
            }
        }
        else if (tutoFlow == 9)
        {
            Tuto9.SetActive(true);
            temp -= Time.fixedDeltaTime;
            if (temp <= 0)
            {
                temp = 2;
                tutoFlow+=9;
                Tuto9.SetActive(false);
            }
        }
        
        else if (tutoFlow == 18
            && PlayerManager.playerSingleton.iteratingEnemy.transform.position.x - PlayerManager.playerSingleton.transform.position.x <= PlayerManager.playerSingleton.AimStartRange)
        {
            Tuto18.SetActive(true);
            
            temp -= Time.fixedDeltaTime;
            if (temp <= 0)
            {
                temp = 2;
                tutoFlow++;
                Tuto18.SetActive(false);
            }
        }
        else if (tutoFlow == 21 && PlayerManager.playerSingleton.trap!=null)
        {
            Tuto21.SetActive(true);
            Time.timeScale = 0.01f;
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Time.timeScale = 1;
                temp = 2;
                tutoFlow++;
                Tuto21.SetActive(false);
            }
        }
        else if (tutoFlow == 22)
        {
            Tuto22.SetActive(true);
            
            temp -= Time.fixedDeltaTime;
            if (temp <= 0)
            {
                temp = 2;
                tutoFlow++;
                Tuto22.SetActive(false);
            }
        }
        else if (tutoFlow == 23
            && PlayerManager.playerSingleton.iteratingEnemy.transform.position.x - PlayerManager.playerSingleton.transform.position.x <= PlayerManager.playerSingleton.AimStartRange)
        {
            Tuto23.SetActive(true);
            Time.timeScale = 0.01f;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Time.timeScale = 1;
                temp = 2;
                tutoFlow++;
                Tuto23.SetActive(false);
            }

        }
        else if(tutoFlow==24)
        {
            Tuto24.SetActive(true);
            temp -= Time.fixedDeltaTime;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                temp = 2;
                tutoFlow++;
                StaticManager.staticInfosSingleTon.isTutoEnd = true;
                Tuto24.SetActive(false);
            }
        }


        if(skillFlow==0 && StageManager.stageSingletom.SkillGained() && tutoFlow>9)
        {
            Tuto10.SetActive(true);
            
            if(Input.GetKeyDown(KeyCode.E))
            {
                skillFlow++;
                Tuto10.SetActive(false);
            }
        }
        else if(skillFlow==1)
        {
            Tuto17.SetActive(true);
            skillTemp -= Time.fixedDeltaTime;
            if (skillTemp<=0)
            {
                skillFlow++;
                Tuto17.SetActive(false);
            }
        }

        if(!isAttTutoEnd && ((tutoFlow >=5 && PlayerManager.playerSingleton.iteratingEnemy != null
            && PlayerManager.playerSingleton.iteratingEnemy.transform.position.x - PlayerManager.playerSingleton.transform.position.x <= PlayerManager.playerSingleton.AimStartRange
            && (PlayerManager.playerSingleton.iteratingEnemy.attackType == AttackType.HORIZON)) || Tuto5.activeInHierarchy))
        {
            if(attTuto==0)
            {
                Tuto5.SetActive(true);
                Time.timeScale = 0.01f;
                if(Input.GetMouseButtonDown(1))
                {
                    Tuto5.SetActive(false);
                    attTuto++;
                    Time.timeScale = 1;
                }
            }
            else if(attTuto==1)
            {
                Tuto6.SetActive(true);
                attTemp -= Time.fixedDeltaTime;
                if(attTemp<=0)
                {
                    Tuto6.SetActive(false);
                    isAttTutoEnd = true;
                    attTuto++;
                    attTemp = 2;
                }
            }
                    
        }

        if(!isDefTutoEnd && tutoFlow >= 5 && ((PlayerManager.playerSingleton.iteratingEnemy!=null
            && PlayerManager.playerSingleton.iteratingEnemy.transform.position.x - PlayerManager.playerSingleton.transform.position.x <= PlayerManager.playerSingleton.AimStartRange
            && PlayerManager.playerSingleton.iteratingEnemy.attackType == AttackType.GUARD)||(defTuto>0 || Tuto13.activeInHierarchy)))
        {
            if (defTuto == 0)
            {
                Tuto13.SetActive(true);
                Time.timeScale = 0.01f;
                if (Input.GetMouseButtonDown(1))
                {
                    Tuto13.SetActive(false);
                    defTuto++;
                }
            }
            else if (defTuto == 1)
            {
                Tuto14.SetActive(true);
                attTemp -= Time.fixedDeltaTime;
                if (attTemp <= 0)
                {
                    Tuto14.SetActive(false);
                    defTuto++;
                    attTemp = 2;
                }
            }
            
            else if (defTuto == 2)
            {
                Tuto16.SetActive(true);
                
                if (Input.GetMouseButtonDown(0))
                {
                    Tuto16.SetActive(false);
                    Time.timeScale = 1;
                    isDefTutoEnd = true;
                    attTemp = 2;
                    defTuto++;
                }
            }

        }
    }
}
