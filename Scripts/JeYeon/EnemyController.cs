using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update

    private float enemy_distance;
    private float enemy_speed = 5.0f;
    public static EnemyController instance
    {
        get
        {
            // ���� �̱��� ������ ���� ������Ʈ�� �Ҵ���� �ʾҴٸ�
            if (m_instance == null)
            {
                // ������ GameManager ������Ʈ�� ã�Ƽ� �Ҵ�
                m_instance = FindObjectOfType<EnemyController>();
            }
            // �̱��� ������Ʈ ��ȯ
            return m_instance;
        }
    }
    private static EnemyController m_instance; // �̱����� �Ҵ�� static ����

    float distance;
    public float Distance
    {
        get
        {
            return distance;
        }
    }


    void Update()
    {
        distance += (float)enemy_speed * Time.deltaTime / 3600; 
    }
}
