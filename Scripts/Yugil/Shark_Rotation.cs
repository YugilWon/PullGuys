using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Shark_Rotation : MonoBehaviour
{
    private NavMeshAgent m_agent;

    // Start is called before the first frame update
    private void Start()
    {
        m_agent = GetComponent<NavMeshAgent>();
        m_agent.updateRotation = false;

    }

    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 forward = new Vector2(transform.position.z, transform.position.x);
        Vector2 steeringTarget = new Vector2(m_agent.steeringTarget.z, m_agent.steeringTarget.x);

        //���� ���� ��, ���Լ��� �� ���ϱ�
        Vector2 dir = steeringTarget - forward;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.eulerAngles = Vector3.up * angle;
    }
}
