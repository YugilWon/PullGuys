using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ���� ���� �����ϴ� ���� �Ŵ���
public class TimeAttackManager : MonoBehaviour
{
    // �̱��� ���ٿ� ������Ƽ
    public static TimeAttackManager instance
    {
        get
        {
            // ���� �̱��� ������ ���� ������Ʈ�� �Ҵ���� �ʾҴٸ�
            if(m_instance == null)
            {
                // ������ GameManager ������Ʈ�� ã�Ƽ� �Ҵ�
                m_instance = FindObjectOfType<TimeAttackManager>();
            }
            // �̱��� ������Ʈ ��ȯ
            return m_instance;
        }
    }

    private static TimeAttackManager m_instance; // �̱����� �Ҵ�� static ����

    // �������� ǥ�� UI
    public Text timeText, distanceText, speedText, endTime;
    public GameObject _info_ui, _kmSet, _end;
    public InputField KMField, TimeField;

    
    private float distance;  // �Ÿ� km����
    public bool gamestate{ get; private set; }

    private TimeUtil.Timer timer;

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
        distance = 0.0f;
        gamestate = true;
        changeUI(km: true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void onClickButton()
    {
        timer = new TimeUtil.Timer(float.Parse(TimeField.text));
        changeUI(info: true);
        StartCoroutine(update());
    }

    private void endGame()
    {
        changeUI(end : true);
        StartCoroutine(endGameNextScene());
    }

    private void changeUI(bool km = false, bool info = false, bool end = false)
    {
        _kmSet.SetActive(km);
        _info_ui.SetActive(info);
        _end.SetActive(end);
    }

    IEnumerator endGameNextScene()
    {
        timer = new TimeUtil.Timer(5.0f);

        while(!timer.isEnd)
        {
            endTime.text = "�����ð� : " + (int)timer.Time + "��";
            yield return null;
        }

        LoadingSceneController.LoadScene("Training");
    }
    IEnumerator update()
    {
        while(!_end.activeSelf)
        {
            // �Ÿ� ���
            distance += (float)SpeedManager.Instance.BoatSpeed * Time.deltaTime / 3600 ;
            distanceText.text = "�Ÿ� : " + (distance).ToString("F3") + "km";

            //�ӵ� ǥ��
            speedText.text = "�ӵ�: " + SpeedManager.Instance.BoatSpeed.ToString("F2") + "km/h";


            // �ð��� UI�� ǥ��
            timeText.text = "�ð� : " + (int)timer.Time / 60 + "�� " + (int)timer.Time % 60 + "��";

            if (timer.isEnd || distance >= float.Parse(KMField.text))
            {
                endGame();
            }

            yield return null;
        }
    }
}
