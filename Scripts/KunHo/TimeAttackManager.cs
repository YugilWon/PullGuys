using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ���� ���� �����ϴ� ���� �Ŵ���
public class TimeAttackManager : MonoBehaviour
{
    // �̱��� ���ٿ� ������Ƽ

    [SerializeField]
    private GameObject progressBar_Prefab;
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

    private float goalDistance = 0.01f;

    public float GoalDistance
    {
        get
        {
            return goalDistance;
        }
    }

    private void Awake()
    {
        // ���� �̱��� ������Ʈ�� �� �ٸ� GameManager ������Ʈ�� �ִٸ�
        if (instance != this)
        {
            // �ڽ��� �ı�
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Instantiate(progressBar_Prefab, GameObject.Find("UI").transform, false);
    }



    void Update()
    {
        if (EnemyController.instance.Distance >= goalDistance || 
             MesureManager.Instance.Distance >= goalDistance )
        {
            endGame();
        }
    }

    private void endGame()
    {
        LoadingSceneController.LoadScene("ModeSelection");  
    }
    
    
}
