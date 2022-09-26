using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public float _speed = 5.0f;
    public float _rotateSpeed = 100f;
    private PlayerInput playerInput; // �÷��̾� �Է��� �˷��ִ� ������Ʈ
    private Rigidbody playerRigidbody; // �÷��̾� ĳ������ ������ٵ�
    private Animator playerAnimator; // �÷��̾� ĳ������ �ִϸ�����

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
    }
 

    
    private void FixedUpdate()
    {
        // ���� ���� �ֱ⸶�� ������, ȸ��, �ִϸ��̼� ó�� ����

        Move();
        playerAnimator.SetFloat("Move", playerInput.move);
    }

    // ĳ���� ������
    private void Move()
    {
        Vector3 moveDistance = playerInput.move * transform.forward * _speed * Time.deltaTime;
        // ������ٵ� �̿��� ���� ������Ʈ ��ġ����
        playerRigidbody.MovePosition(playerRigidbody.position + moveDistance);
    }
    
}
    

