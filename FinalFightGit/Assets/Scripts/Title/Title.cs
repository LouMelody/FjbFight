using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    [Header("SE")]
    public AudioClip menuSE;
    [Header("KeyBinding")]
    public GameObject keyBinding;

    AudioSource audioSource;

    void Start () 
    {
        //Componentを取得
        audioSource = GetComponentInParent<AudioSource>();
    }

    //??????????????
    void Update()
    {
        //????????????????
        if (Input.GetMouseButtonDown(0))
        {
            keyBinding.SetActive(false);
        }
    }

    public void PlayButton()
    {
        //効果音
        audioSource.PlayOneShot(menuSE);

        SceneManager.LoadScene("SampleScene");
    }

    public void KeyBindingButton()
    {
        //効果音
        audioSource.PlayOneShot(menuSE);

        keyBinding.SetActive(true);
    }
}
