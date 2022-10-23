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

    private void Awake()
    {
        // ���� �̱��� ������Ʈ�� �� �ٸ� GameManager ������Ʈ�� �ִٸ�
        if (instance != this)
        {
            // �ڽ��� �ı�
            Destroy(gameObject);
        }
    }



    void Update()
    {
        if (EnemyController.instance.Distance >= 2 || 
             MesureManager.Instance.Distance >= 2 )
        {
            endGame();
        }

    }

    private void endGame()
    {
        LoadingSceneController.LoadScene("ModeSelection");
        
    }
    
    
}
