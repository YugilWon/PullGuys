using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ���� ���� �����ϴ� ���� �Ŵ���
public class TrainGameManager : MonoBehaviour
{
    public GameObject feverDialog;
    private bool feverMode;


    void Start()
    {
        feverMode = false;

        SoundManager.Instance.setBackGroundMusic(BGMList.Instance.getAudioClip(NameUtil.SOUND_BGM));
    }

    // Update is called once per frame
    void Update()
    {
        if (MesureManager.Instance.Timer.Time % 600 == 0 && !feverMode)
        {
            GameObject gameObject = Instantiate(feverDialog);
            gameObject.transform.SetParent(GameObject.Find("UI").transform, false);
            gameObject.transform.SetAsFirstSibling();
            feverMode = true;
        }

    }
}
