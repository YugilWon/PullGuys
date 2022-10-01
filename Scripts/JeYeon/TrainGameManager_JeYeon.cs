using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ���� ���� �����ϴ� ���� �Ŵ���
public class TrainGameManager_JeYeon : MonoBehaviour
{
    // �̱��� ���ٿ� ������Ƽ
    public static TrainGameManager_JeYeon instance
    {
        get
        {
            // ���� �̱��� ������ ���� ������Ʈ�� �Ҵ���� �ʾҴٸ�
            if(m_instance == null)
            {
                // ������ GameManager ������Ʈ�� ã�Ƽ� �Ҵ�
                m_instance = FindObjectOfType<TrainGameManager_JeYeon>();
            }
            // �̱��� ������Ʈ ��ȯ
            return m_instance;
        }
    }

    private static TrainGameManager_JeYeon m_instance; // �̱����� �Ҵ�� static ����


    GameObject player;
    public Text timeText;

    private float playTime;
    private void Awake()
    {
        // ���� �̱��� ������Ʈ�� �� �ٸ� GameManager ������Ʈ�� �ִٸ�
        if (instance != this)
        {
            // �ڽ��� �ı�
            Destroy(gameObject);
        }
    } 

    
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        PlayerState(false);
        TrainUIManager_JeYeon.instance.LoadKmSetUI();
     
    }

    // Update is called once per frame
    void Update()
    {
       
        // UI ����
        if (Input.GetKey(KeyCode.W))
        {
            TrainUIManager_JeYeon.instance.UpdateSpeedText();
        }

        /*
        if (TrainUIManager.instance.distance != 0)
        {
            playTime += Time.deltaTime;
        }
        else
        {
            playTime = 0;
        }

        timeText.text = "�ð� : " + (int)playTime / 60 + "�� " + (int)playTime % 60 + "��";


        if (TrainUIManager.instance.goalDistance != 0 && TrainUIManager.instance.distance >= TrainUIManager.instance.goalDistance)
        {
            EndGame();
        }
        */

    }

    public void PlayerState(bool state)
    {
        player.GetComponent<PlayerController>().enabled = state;
        player.GetComponent<PlayerInput>().enabled = state;
        player.GetComponent<AudioSource>().enabled = state;
        player.GetComponent<Animator>().enabled = state;
        player.GetComponent<Rigidbody>().useGravity = state;
        
    }

    public void EndGame()
    {
        //TrainUIManager.instance.LoadEndUI();

        PlayerState(false);
    }
}
