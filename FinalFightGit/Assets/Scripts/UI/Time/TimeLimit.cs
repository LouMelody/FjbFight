using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeLimit : MonoBehaviour
{
    //制限時間
    public float limitTime;
    //時間を表示するText型の変数
    public Text timeText;

    void Update()
    {
        //時間をカウントダウンする
        limitTime -= Time.deltaTime;
 
        //時間を表示する
        timeText.text = limitTime.ToString("f0");
 
        //limitTimeが0以下になったとき
        if (limitTime <= 0)
        {
            Debug.Log("制限時間オーバー");
        }
    }
}
