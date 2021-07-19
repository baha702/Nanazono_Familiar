using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class start : MonoBehaviour
{
    private AudioSource audio;
    public AudioClip startClip;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            {
                audio.PlayOneShot(startClip, 1.0f);
                SceneManager.LoadScene("Tutorial");
            }

        }
    } 
    
    public void StartGame()
    {
        //audio.PlayOneShot(startClip, 1.0f);
        SceneManager.LoadScene("OptionScene");
    }
}
