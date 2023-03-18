using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossEnemyHP : MonoBehaviour
{
    //????HP????????HP?B
    float maxHp = 500;
    float currentHp;

    void Start()
    {
        //??????HP??????HP?????????B
        currentHp = maxHp;
    }

    //???_???[?W???f????
    public void TakeDamage(float damage)
    {
        currentHp = Mathf.Max(currentHp - damage, 0);
        GameClear();
    }

    private void GameClear()
    {
        if(currentHp <= 0)
        {
            SceneManager.LoadScene("Clear");
        }
    }
}

