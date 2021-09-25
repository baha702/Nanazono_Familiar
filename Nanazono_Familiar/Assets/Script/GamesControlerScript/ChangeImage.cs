using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeImage : MonoBehaviour
{
  
   
    public GameObject Gif01,Gif02;
    public GameObject nextbutton;
    public GameObject returnbutton;
    public GameObject VoiceOtionText;
    public GameObject MikeOptionText;

    public void Start()
    {
        
    }
    public void NextImage()
    {
        CriAtomSource atomSrc = gameObject.GetComponent<CriAtomSource>();
        if (atomSrc != null)
        {
            atomSrc.Play();

        }
        if (Gif02.activeSelf)
        {
            SceneManager.LoadScene("Start Voice");
        }
        if (Gif01.activeSelf)
        {
            Gif01.SetActive(false);
            Gif02.SetActive(true);
            if (!nextbutton.activeSelf)
            {
                nextbutton.SetActive(true);
                Debug.Log("next1");
            }
            if (!returnbutton.activeSelf)
            {
                returnbutton.SetActive(true);
               
            }
            VoiceOtionText.SetActive(false);
            MikeOptionText.SetActive(true); 
        }
       
    }
    public void ReturnImage()
    {

        CriAtomSource atomSrc = gameObject.GetComponent<CriAtomSource>();
        if (atomSrc != null)
        {
            atomSrc.Play();

        }

        if (Gif02.activeSelf)
        {
            Gif02.SetActive(false);
            Gif01.SetActive(true);
            if (returnbutton.activeSelf)
            {
                returnbutton.SetActive(false);
                MikeOptionText.SetActive(false);
                VoiceOtionText.SetActive(true);
                Debug.Log("retruen1");
            }
        }
       
    }
    public void SkipTutorial()
    {

        CriAtomSource atomSrc = gameObject.GetComponent<CriAtomSource>();
        if (atomSrc != null)
        {
            atomSrc.Play(7);

        }

        SceneManager.LoadScene("StageChoice");
    }
   
}
