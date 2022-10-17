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


    private Text distanceAndTimeText;
    private float time;
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
        time = 60.0f;
        distance = 0.0f;
        gamestate = true;
        timer = new TimeUtil.Timer(time);

        // Update is called once per frame
    }


    void Update()
    {
       
    }

    private void endGame()
    {
        StartCoroutine(endGameNextScene());
    }


    IEnumerator endGameNextScene()
    {
        timer = new TimeUtil.Timer(5.0f);


        while(!timer.isEnd)
        {
            yield return null;
        }

        LoadingSceneController.LoadScene("Training");
    }
}
