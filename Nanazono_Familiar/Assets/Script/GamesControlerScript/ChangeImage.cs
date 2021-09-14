﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeImage : MonoBehaviour
{
    public Sprite image1;
    public Sprite image2;
    public Sprite image3;
    public Sprite image4;
    public Sprite image5;
    public Image img;
    public GameObject nextbutton;
    public GameObject returnbutton;

    public void Start()
    {
        img = GetComponent<Image>();
        img.sprite = image1;
    }
    public void NextImage()
    {
        CriAtomSource atomSrc = gameObject.GetComponent<CriAtomSource>();
        if (atomSrc != null)
        {
            atomSrc.Play();

        }
        if (img.sprite == image1)
        {
            img.sprite = image2;
            if (!nextbutton.activeSelf)
            {
                nextbutton.SetActive(true);
                Debug.Log("next1");
            }
            if (!returnbutton.activeSelf)
            {
                returnbutton.SetActive(true);
               
            }
        }
        else if(img.sprite == image2)
        {
            img.sprite = image3;
        }
        else if(img.sprite == image3)
        {
            img.sprite = image4;
        }
        else if(img.sprite == image4)
        {
            img.sprite = image5;
        }
        else if (img.sprite == image5)
        {
            SceneManager.LoadScene("StageChoice");
        }
       
    }
    public void ReturnImage()
    {

        CriAtomSource atomSrc = gameObject.GetComponent<CriAtomSource>();
        if (atomSrc != null)
        {
            atomSrc.Play();

        }

        if (img.sprite == image2)
        {
            img.sprite = image1;
            if (returnbutton.activeSelf)
            {
                returnbutton.SetActive(false);
                Debug.Log("retruen1");
            }
        }
        else if (img.sprite == image3)
        {
            img.sprite = image2;
            if (!nextbutton.activeSelf)
            {
                nextbutton.SetActive(true);
                Debug.Log("return2");
            }
        }
        else if (img.sprite == image4)
        {
            img.sprite = image3;
            if (!nextbutton.activeSelf)
            {
                nextbutton.SetActive(true);
                Debug.Log("return3");
            }
        }
        else if (img.sprite == image5)
        {
            img.sprite = image4;
            if (!nextbutton.activeSelf)
            {
                nextbutton.SetActive(true);
                Debug.Log("return4");
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
