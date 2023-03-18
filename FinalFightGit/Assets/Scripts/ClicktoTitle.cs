using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClicktoTitle : MonoBehaviour
{
    //クリックでタイトルに移動する処理
    void Update()
    {
        //左クリックでタイトル画面に遷移する処理
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Title");
        }
    }
}
