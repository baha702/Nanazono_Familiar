using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour
{
    public GameObject PlayerObject;
    public GameObject ChargeEffect;
    public GameObject ExeprodeEffect;

    bool ChargeBool;
    bool ExpBool;
    bool flag1;

    KotodamariScript kotodamascript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (true)
        {
            ChargeEffect.gameObject.SetActive(true);
        }
        else
        {
            //ChargeEffect.gameObject.SetActive(false);
        }

        if(ExpBool==true)
        {
            GameObject.Instantiate(ExeprodeEffect, kotodamascript.PlayerPos, Quaternion.identity);
            Destroy(ExeprodeEffect,5);
        }
    }
}
