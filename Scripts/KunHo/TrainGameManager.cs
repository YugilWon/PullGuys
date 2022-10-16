using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ���� ���� �����ϴ� ���� �Ŵ���
public class TrainGameManager : MonoBehaviour
{
    public GameObject feverDialog;
    private bool feverMode;
    private Text distanceAndTimeText;
    private float distance;  // �Ÿ� km����
    private TimeUtil.StopWatch stopWatch;


    void Start()
    {
        feverMode = false;
        distance = 0.0f;
        distanceAndTimeText = GameObject.Find("Distance&Time").transform.Find("Text").GetComponent<Text>();


        stopWatch = new TimeUtil.StopWatch();
        SoundManager.Instance.setBackGroundMusic(BGMList.Instance.getAudioClip(NameUtil.SOUND_BGM));
    }

    // Update is called once per frame
    void Update()
    {
        // �Ÿ� ���
        distance += (float)SpeedManager.Instance.BoatSpeed * Time.deltaTime / 3600;

        if(((int)stopWatch.Time / 5) % 2 == 0)
        {
            distanceAndTimeText.text = "�Ÿ� : " + (distance).ToString("F3") + "km";
        }
        else
        {
            distanceAndTimeText.text = "�ð� : " + (int)stopWatch.Time / 60 + "�� " + (int)stopWatch.Time % 60 + "��";
        }

        if ((int)stopWatch.Time % 600 == 0 && !feverMode)
        {
            GameObject gameObject = Instantiate(feverDialog);
            gameObject.transform.SetParent(GameObject.Find("UI").transform, false);
            gameObject.transform.SetAsFirstSibling();
            feverMode = true;
        }

    }
}
