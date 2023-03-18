using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPBar : MonoBehaviour
{
    //最大HPと現在のHP。
    float maxHp = 1000;
    float currentHp;
    //HPBar_Playerを入れる
    public Slider slider;

    void Start()
    {
        //Sliderを満タンにする。
        slider.value = 1;
        //現在のHPを最大HPと同じに。
        currentHp = maxHp;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Mid")
        {
            TakeDamage(10);
            Debug.Log("damage");
        }
    }
    //被ダメージ反映処理
    public void TakeDamage(float damage)
    {
        var tempHp = Mathf.Max(currentHp -= damage, 0);
        slider.value = (tempHp / maxHp);
    }
}
