using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    [Header("SE")]
    public AudioClip menuSE;

    AudioSource audioSource;

    void Start () 
    {
        //Component���擾
        audioSource = GetComponentInParent<AudioSource>();
    }

    public void PlayButton()
    {
        //���ʉ�
        audioSource.PlayOneShot(menuSE);

        SceneManager.LoadScene("SampleScene");
    }
}
