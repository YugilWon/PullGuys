using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DistanceText : MonoBehaviour
{

    Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = transform.Find("Text").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        float time = MesureManager.Instance.Timer.Time;
        if (((int)time / 5) % 2 == 0)
        {
            text.text = "�Ÿ� : " + (MesureManager.Instance.Distance).ToString("F3") + "km";
        }
        else
        {
            text.text = "�ð� : " + (int)time / 60 + "�� " + (int)time % 60 + "��";
        }
    }
}
