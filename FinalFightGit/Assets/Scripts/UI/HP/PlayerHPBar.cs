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
        if(collision.gameObject.name == "Mid")
        {
            TakeDamage(10);
            Debug.Log("damage");
        }
    }
    //��_���[�W���f����
    public void TakeDamage(float damage)
    {
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
        if (Input.GetKeyDown(KeyCode.D))
        {
            //���ʉ�
            audioSource.PlayOneShot(damageSE);
            var tempHp = Mathf.Max(currentHp -= 500f, 0);
            slider.value = (tempHp / maxHp);
            GameOver();
        }
    }
}
