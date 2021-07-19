using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeImage : MonoBehaviour
{
    public Sprite image1;
    public Sprite image2;
    public Sprite image3;
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
        else if (img.sprite == image3)
        {
            SceneManager.LoadScene("Tutorial");
        }
       
    }
    public void ReturnImage()
    {
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
    }
    public void SkipTutorial()
    {
        SceneManager.LoadScene("Nepuri-gu");
    }
   
}
