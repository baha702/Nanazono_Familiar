using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TutorialKey : MonoBehaviour
{
    private AudioSource audio;
    public AudioClip startClip;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void StartGame()
    {
        /*CriAtomSource atomSrc = gameObject.GetComponent<CriAtomSource>();
        if (atomSrc != null)
        {
            atomSrc.Play();

        }*/
        //audio.PlayOneShot(startClip, 1.0f);
        SceneManager.LoadScene("Tutorial");
    }
}