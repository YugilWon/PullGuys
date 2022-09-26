using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerAnimator.SetFloat("Move", 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        // ���� ���� �ֱ⸶�� ������, ȸ��, �ִϸ��̼� ó�� ����

        if (!SpeedManager.Instance.isStop)
            playerAnimator.SetFloat("Move", 1.0f);
        else
            playerAnimator.SetFloat("Move", 0.0f);
    }

}
