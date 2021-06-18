using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitKey : MonoBehaviour
{
    private AudioSource audio;
    public AudioClip QuitClip;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
      UnityEngine.Application.Quit();
#endif
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) Quit();
        //audio.PlayOneShot(titleClip, 1.0f);
    }
}