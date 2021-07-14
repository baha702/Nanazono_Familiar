using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour
{
    public Sprite image1;
    public Sprite image2;
    public Sprite image3;
    Image img;
    public GameObject nextbutton;
    public GameObject returnbutton;

    private void Start()
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
            }
            if (!returnbutton.activeSelf)
            {
                returnbutton.SetActive(true);
            }
        }
        else if(img.sprite == image2)
        {
            img.sprite = image3;
            if (nextbutton.activeSelf)
            {
                nextbutton.SetActive(false);
            }
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
            }
        }
        else if (img.sprite == image3)
        {
            img.sprite = image2;
            if (!nextbutton.activeSelf)
            {
                nextbutton.SetActive(true);
            }
        }
    }
}
