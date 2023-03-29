using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHPBar : MonoBehaviour
{
    //最大HPと現在のHP。
    float maxHp = 1000;
    float currentHp;
    //HPBar_Playerを入れる
    public Slider slider;

    [Header("SE")]
    public AudioClip damageSE;
    public AudioClip gameoverSE;

    private AudioSource audioSource;
    private bool isGameOverSeEnd;

    void Start()
    {
        //Sliderを満タンにする。
        slider.value = 1;
        //現在のHPを最大HPと同じに。
        currentHp = maxHp;
        //Componentを取得
        audioSource = GetComponent<AudioSource>();
        //GameOverのSEが終了を確認する用
        isGameOverSeEnd = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Low")
        {
            TakeDamage(50);
            Debug.Log("lowDamage");
        }
        if(collision.gameObject.name == "Mid")
        {
            TakeDamage(50);
            Debug.Log("midDamage");
        }
        if(collision.gameObject.name == "High")
        {
            TakeDamage(50);
            Debug.Log("highDamage");
        }
    }
    //被ダメージ反映処理
    public void TakeDamage(float damage)
    {
        Debug.Log("damage");
        //効果音
        audioSource.PlayOneShot(damageSE);

        var tempHp = Mathf.Max(currentHp -= damage, 0);
        slider.value = (tempHp / maxHp);
        GameOver();
    }
    
    private void GameOver()
    {
        if(currentHp <= 0)
        {
            //効果音
            audioSource.PlayOneShot(gameoverSE);
            isGameOverSeEnd = true;
        }
    }

    void Update()
    {
        if(!audioSource.isPlaying && isGameOverSeEnd)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
