using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPBar : MonoBehaviour
{
    //�ő�HP�ƌ��݂�HP�B
    int maxHp = 1000;
    int currentHp;
    //HPBar_Player������
    public Slider slider;

    void Start()
    {
        //Slider�𖞃^���ɂ���B
        slider.value = 1;
        //���݂�HP���ő�HP�Ɠ����ɁB
        currentHp = maxHp;
        Debug.Log("Start currentHp : " + currentHp);
    }
}
