using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour
{
    public GameObject PlayerObject;
    public GameObject ChargeEffect;
    public GameObject ExeprodeEffect;
    public GameObject MainCamera;
    public GameObject CursorObject;

    public bool ChargeBool;
    public bool ExpBool;
    bool flag1;
    KotodamariScript kotodamascript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (ChargeBool==true)
        {
            ChargeEffect.gameObject.SetActive(true);
            flag1 = true;
        }
        if (flag1==true)
        {
            ChargeEffect.gameObject.SetActive(false);
            flag1 = false;
            ChargeBool = true;
        }
        if(ExpBool==true)
        {
            GameObject.Instantiate(ExeprodeEffect, kotodamascript.PlayerPos, Quaternion.identity);
            Destroy(ExeprodeEffect,5);
        }
    }
}
