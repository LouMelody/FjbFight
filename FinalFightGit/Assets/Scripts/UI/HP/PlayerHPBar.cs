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
        if(collision.gameObject.name == "Mid")
        {
            TakeDamage(10);
            Debug.Log("damage");
        }
    }
    //被ダメージ反映処理
    public void TakeDamage(float damage)
    {
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
        if (Input.GetKeyDown(KeyCode.D))
        {
            //効果音
            audioSource.PlayOneShot(damageSE);
            var tempHp = Mathf.Max(currentHp -= 500f, 0);
            slider.value = (tempHp / maxHp);
            GameOver();
        }
    }
}
