using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHPBar : MonoBehaviour
{
    //�ő�HP�ƌ��݂�HP�B
    float maxHp = 1000;
    float currentHp;
    //HPBar_Player������
    public Slider slider;

    [Header("SE")]
    public AudioClip damageSE;
    public AudioClip gameoverSE;

    private AudioSource audioSource;
    private bool isGameOverSeEnd;

    void Start()
    {
        //Slider�𖞃^���ɂ���B
        slider.value = 1;
        //���݂�HP���ő�HP�Ɠ����ɁB
        currentHp = maxHp;
        //Component���擾
        audioSource = GetComponent<AudioSource>();
        //GameOver��SE���I�����m�F����p
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
    //��_���[�W���f����
    public void TakeDamage(float damage)
    {
        Debug.Log("damage");
        //���ʉ�
        audioSource.PlayOneShot(damageSE);

        var tempHp = Mathf.Max(currentHp -= damage, 0);
        slider.value = (tempHp / maxHp);
        GameOver();
    }
    
    private void GameOver()
    {
        if(currentHp <= 0)
        {
            //���ʉ�
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
