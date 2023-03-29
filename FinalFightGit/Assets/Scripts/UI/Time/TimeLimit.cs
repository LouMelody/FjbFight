using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeLimit : MonoBehaviour
{
    //��������
    public float limitTime;
    //���Ԃ�\������Text�^�̕ϐ�
    public Text timeText;

    void Update()
    {
        //���Ԃ��J�E���g�_�E������
        limitTime -= Time.deltaTime;
 
        //���Ԃ�\������
        timeText.text = limitTime.ToString("f0");
 
        //limitTime��0�ȉ��ɂȂ����Ƃ�
        if (limitTime <= 0)
        {
            SceneManager.LoadScene("GameOver");
            Debug.Log("�������ԃI�[�o�[");
        }
    }
}
