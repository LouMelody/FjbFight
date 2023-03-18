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
        //Componentを取得
        audioSource = GetComponentInParent<AudioSource>();
    }

    public void PlayButton()
    {
        //効果音
        audioSource.PlayOneShot(menuSE);

        SceneManager.LoadScene("SampleScene");
    }
}
