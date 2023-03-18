using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    //最大HPと現在のHP。
    float maxHp = 100;
    float currentHp;

    void Start()
    {
        //現在のHPを最大HPと同じに。
        currentHp = maxHp;
    }

    //被ダメージ反映処理
    public void TakeDamage(float damage)
    {
        currentHp = Mathf.Max(currentHp - damage, 0);
    }

}
