using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KotodamaTextData : MonoBehaviour
{
    public KotodamariScript kotodamari;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject FlyingObject;
        FlyingObject = GameObject.Find("TextPrefab");
        //FlyingText.UpdateObject(FlyingObject, kotodamari.inputText);
        
    }
}
