using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Progress : MonoBehaviour
{
    
    public Image progressImage;
    public Image PlayerIcon;
    

    //���α׷��� ��
    float pbValue;

    void Update()
    {
        //�ð� ���� ���� ������Ų��.
        pbValue += Time.deltaTime;
        
        float x = progressImage.rectTransform.sizeDelta.x * progressImage.rectTransform.localScale.x;
        
        progressImage.fillAmount = pbValue / 10;

        float positionX = x * progressImage.fillAmount - (x/2);
        
        

        PlayerIcon.rectTransform.localPosition = new Vector3(positionX, PlayerIcon.rectTransform.localPosition.y,
            PlayerIcon.rectTransform.localPosition.z);
        
        
        

    }
}
