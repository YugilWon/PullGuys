using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButtonListener : MonoBehaviour
{
    GameObject modeChangeButton, SettingButton;
    Toggle toggle;
    // Start is called before the first frame update
    void Start()
    {
        modeChangeButton = GameObject.Find("MenuButtons").transform.Find("ModeChangeButton").gameObject;
        SettingButton = GameObject.Find("MenuButtons").transform.Find("SettingButton").gameObject;

        toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(
            delegate {
                clickMenuButton();
            });

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clickMenuButton()
    {
        if (toggle.isOn)
        {
            modeChangeButton.GetComponent<ButtonSlideAnimation>().Open(1);
            SettingButton.GetComponent<ButtonSlideAnimation>().Open(2);
        }
        else // �ִϸ��̼��� ������, ������Ʈ�� ������
        {
            modeChangeButton.GetComponent<ButtonSlideAnimation>().Close();
            SettingButton.GetComponent<ButtonSlideAnimation>().Close();
        }

    }
}
