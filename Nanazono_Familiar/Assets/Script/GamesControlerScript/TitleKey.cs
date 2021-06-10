using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows.Speech;

public class TitleKey : MonoBehaviour
{
    //　タイトルキー
    [SerializeField]
    private GameObject Title;
    private AudioSource audio;
    public AudioClip titleClip;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("t"))
        {
            //audio.PlayOneShot(titleClip, 1.0f);
            SceneManager.LoadScene("Start");
            

        }
    }
}