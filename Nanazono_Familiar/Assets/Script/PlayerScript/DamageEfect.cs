using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageEfect : MonoBehaviour
{
     Image img;
    // Start is called before the first frame update
    void Start()
    {
        GameObject imgObject = GameObject.Find("DamageEfect");
        img = imgObject.GetComponent<Image>();
        img.color = new Color(1f, 1f, 1f, 0f);
        img.color = Color.clear;
    }

    // Update is called once per frame
    void Update()
    {
        this.img.color = Color.Lerp(this.img.color, Color.clear, Time.deltaTime);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            img.GetComponent<Image>().color = new Color(0.5f, 0f, 0f, 0.5f);
        }
        else
        {
            img.GetComponent<Image>().color = Color.Lerp(img.color, Color.clear, Time.deltaTime);
        }
    }
}
