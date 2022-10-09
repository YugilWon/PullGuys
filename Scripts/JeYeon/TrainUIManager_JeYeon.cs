using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using UnityEditor;

public class TrainUIManager_JeYeon : MonoBehaviour
{
    public static TrainUIManager_JeYeon instance
    {
        get
        {
            // ���� �̱��� ������ ���� ������Ʈ�� �Ҵ���� �ʾҴٸ�
            if (m_instance == null)
            {
                // ������ GameManager ������Ʈ�� ã�Ƽ� �Ҵ�
                m_instance = FindObjectOfType<TrainUIManager_JeYeon>();
            }
            // �̱��� ������Ʈ ��ȯ
            return m_instance;
        }
    }

    private static TrainUIManager_JeYeon m_instance; // �̱����� �Ҵ�� static ����


    public GameObject ExitUI;
    public GameObject SettingUI;
    public GameObject ModeUI;
    public Toggle toggle;
    public GameObject modeButton;
    public GameObject SetButton;
    public GameObject menuButton;

    private float _speed;
    public Text speedText;

    private void Awake()
    {
       
    }

    public void OpenSettingUI()
    {
        

        SettingUI.SetActive(true);

        popupSystem popupScript = SettingUI.GetComponent<popupSystem>();

        popupScript.SetYesCallback(() =>
        {
            SettingUI.GetComponent<Animator>().SetTrigger("close");
            
        });
        popupScript.SetNoCallback(() =>
        {
            SettingUI.GetComponent<Animator>().SetTrigger("close");
            
        });
    
    }
    public void OpenExitUI()
    {
        

        ExitUI.SetActive(true);

        popupSystem popupScript = ExitUI.GetComponent<popupSystem>();

        popupScript.SetYesCallback(() =>
        {
            ExitUI.GetComponent<Animator>().SetTrigger("close");
            //ExitUI.SetActive(false);
        });
        popupScript.SetNoCallback(() =>
        {
            ExitUI.GetComponent<Animator>().SetTrigger("close");
            //ExitUI.SetActive(false);
        });

    }

    public void OpenModeUI()
    {
        /*
        GameObject obj = Resources.Load<GameObject>("Prefabs/ExitUI");
        GameObject parent = GameObject.Find("UI");
        GameObject settingUI = Instantiate<GameObject>(obj, parent.transform, false);
        */

        ModeUI.SetActive(true);

        popupSystem popupScript = ModeUI.GetComponent<popupSystem>();

        popupScript.SetYesCallback(() =>
        {
            ModeUI.GetComponent<Animator>().SetTrigger("close");
            //ExitUI.SetActive(false);
        });
        popupScript.SetNoCallback(() =>
        {
            ModeUI.GetComponent<Animator>().SetTrigger("close");
            //ExitUI.SetActive(false);
        });

    }
    public void clickMenuButton()
    {
        
        if (toggle.isOn)
        {
            modeButton.SetActive(true);
            SetButton.SetActive(true);
        }
        else // �ִϸ��̼��� ������, ������Ʈ�� ������
        {
            modeButton.GetComponent<Animator>().SetTrigger("close");
            SetButton.GetComponent<Animator>().SetTrigger("close");
        }

    }


    public void UpdateSpeedText(float speed)
    {
        speedText.text = "�ӵ� : " + speed + " km/h";
    }

}
