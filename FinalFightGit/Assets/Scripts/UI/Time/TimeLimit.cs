using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
            Debug.Log("�������ԃI�[�o�[");
        }
    }
}
