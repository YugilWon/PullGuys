using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SharkGameManager : MonoBehaviour
{
    private static SharkGameManager m_instance;
    // �̱��� ���ٿ� ������Ƽ
    public static SharkGameManager instance
    {
        get
        {
            // ���� �̱��� ������ ���� ������Ʈ�� �Ҵ���� �ʾҴٸ�
            if(m_instance == null)
            {
                m_instance = FindObjectOfType<SharkGameManager>();
            }

            return m_instance;
        }
    }


    // ���ӿ� �ʿ��� ����
    private GameObject player;
    private TimeUtil.StopWatch stopWatch;
    private SharkUI UI;
    private Text distanceAndTimeText;
    private float distance;  // �Ÿ� km����


    private void Awake()
    {
        // ���� �̱��� ������Ʈ�� �� �ٸ� SharkGameManager ������Ʈ�� �ִٸ�
        if (instance != this)
        {
            // �ڽ��� �ı�
            Destroy(gameObject);
        }
    }

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        distanceAndTimeText = GameObject.Find("Distance&Time").transform.Find("Text").GetComponent<Text>();
        stopWatch = new TimeUtil.StopWatch();
    }

    // Update is called once per frame
    void Update()
    {
        distance += (float)SpeedManager.Instance.BoatSpeed * Time.deltaTime / 3600;

        if (((int)stopWatch.Time / 5) % 2 == 0)
        {
            distanceAndTimeText.text = "�Ÿ� : " + (distance).ToString("F3") + "km";
        }
        else
        {
            distanceAndTimeText.text = "�ð� : " + (int)stopWatch.Time / 60 + "�� " + (int)stopWatch.Time % 60 + "��";
        }
    }

    public void UpdateUI(float surviveTime, float speed)
    {
        UI.UpdateInfoUI(surviveTime, speed);
    }

    public void EndGame()
    {
        player.GetComponentInChildren<CharacterManager>().enabled = false;
        player.GetComponent<Animator>().enabled = false;
    }

}
