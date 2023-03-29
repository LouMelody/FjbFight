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
        //Component‚ðŽæ“¾
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
        //Œø‰Ê‰¹
        audioSource.PlayOneShot(menuSE);

        SceneManager.LoadScene("SampleScene");
    }

    public void KeyBindingButton()
    {
        //Œø‰Ê‰¹
        audioSource.PlayOneShot(menuSE);

        keyBinding.SetActive(true);
    }
}
