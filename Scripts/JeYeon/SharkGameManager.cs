using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        //stopWatch = new TimeUtil.StopWatch();
        UI = FindObjectOfType<SharkUI>();
        UI.startGameUI();
    }

    // Update is called once per frame
    void Update()
    {
        //UpdateUI(stopWatch.Time, (float)SpeedManager.Instance.BoatSpeed);
    }

    public void UpdateUI(float surviveTime, float speed)
    {
        UI.UpdateInfoUI(surviveTime, speed);
    }

    public void EndGame()
    {
        player.GetComponent<PlayerController>().enabled = false;
        player.GetComponent<PlayerInput>().enabled = false;
        player.GetComponentInChildren<CharacterManager>().enabled = false;
        player.GetComponent<Animator>().enabled = false;

        UI.endGameUI();
    }
}
