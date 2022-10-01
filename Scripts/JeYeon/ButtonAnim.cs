using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnim : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        
    }

    /*
    public void SetDisable(string animName)
    {
        StartCoroutine(disable(animName));
    }

    IEnumerator disable(string animName)
    {
        anim.SetTrigger("close");
        //Debug.Log(anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
        while (anim.GetCurrentAnimatorStateInfo(0).IsName(animName) &&
            anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
        {
            Debug.Log("���Ϲ�");   
            yield return null;
        }
        transform.gameObject.SetActive(false);
    }
    
    */
    
    
    private void Update()
    {

        //Debug.Log(anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("slidClose") || anim.GetCurrentAnimatorStateInfo(0).IsName("setslidClose"))
        {
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1) // �ִϸ��̼��� ��������
            {
                transform.gameObject.SetActive(false);
            }
        }
        
    }
    
}
