using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClicktoTitle : MonoBehaviour
{
    //�N���b�N�Ń^�C�g���Ɉړ����鏈��
    void Update()
    {
        //���N���b�N�Ń^�C�g����ʂɑJ�ڂ��鏈��
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Title");
        }
    }
}
