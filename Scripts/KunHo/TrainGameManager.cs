using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ���� ���� �����ϴ� ���� �Ŵ���
public class TrainGameManager : MonoBehaviour
{
    // �������� ǥ�� UI
    public Text timeText;
    public Text distanceText;
    public Text speedText;
    
    private float distance;  // �Ÿ� km����

    public GameObject _info_ui;
    private TimeUtil.StopWatch stopWatch;


    void Start()
    {
        _info_ui.SetActive(false);
        distance = 0.0f;

        stopWatch = new TimeUtil.StopWatch();
    }

    // Update is called once per frame
    void Update()
    {
        // �Ÿ� ���
        distance += (float)SpeedManager.Instance.BoatSpeed * Time.deltaTime / 3600 ;
        distanceText.text = "�Ÿ� : " + (distance).ToString("F3") + "km";

        TrainUIManager_JeYeon.instance.UpdateSpeedText((float)SpeedManager.Instance.BoatSpeed);

        // �ð��� UI�� ǥ��
        timeText.text = "�ð� : " + (int)stopWatch.Time / 60 + "�� "+ (int)stopWatch.Time % 60 + "��";
    }
    
}
