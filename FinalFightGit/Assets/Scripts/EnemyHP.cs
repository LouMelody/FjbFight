using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    //�ő�HP�ƌ��݂�HP�B
    float maxHp = 100;
    float currentHp;

    void Start()
    {
        //���݂�HP���ő�HP�Ɠ����ɁB
        currentHp = maxHp;
    }

    //��_���[�W���f����
    public void TakeDamage(float damage)
    {
        currentHp = Mathf.Max(currentHp - damage, 0);
    }

}
