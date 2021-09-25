using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItemScript : MonoBehaviour
{
    private GameObject player;
    PlayerHPBar2 hpScript;
    float healpoint = 0.2f;
    bool calledOnce;
    public Material redMaterial;
    Vector3 AppleScal;
    float time = 0.0f;
    bool red = false;

    void Start()
    {
        player = GameObject.Find("Player");
        hpScript = player.GetComponent<PlayerHPBar2>();
        calledOnce = true;
        AppleScal = this.gameObject.transform.localScale;
    }

    void FixedUpdate()
    {
        time += Time.deltaTime;
        //0.1秒毎にHealPointを増やす関数を呼び出すよ。
        if(time >= 0.1f)
        {
            IncreaseHealPoint();
            time = 0.0f;
        }
        //リンゴの大きさが200になったら完熟させるよ。
        if (AppleScal.x >= 200.0f)
        {
            ChangeRed();
        }
    }

    //HealPointを増加させる関数
    private void IncreaseHealPoint()
    {
        //完熟してたり落ちてたらreturnする。
        if (red) return;
        healpoint += 0.007f;
        Vector3 add = new Vector3(0.35f, 0.35f, 0.35f);
        AppleScal += add;
        gameObject.transform.localScale = AppleScal;
    }

    private void ChangeRed()
    {
        this.transform.localScale = new Vector3(200, 200, 200);
        healpoint = 3.0f;
        GetComponent<Renderer>().material.color = redMaterial.color;
        red = true;
    }

    private void FallApple()
    {
        CriAtomSource atomSrc = gameObject.GetComponent<CriAtomSource>();
        if (atomSrc != null)
        {
            atomSrc.Play();
        }

        Rigidbody rigidbody = this.gameObject.GetComponent<Rigidbody>();
        rigidbody.isKinematic = false;
        rigidbody.useGravity = true;
        this.gameObject.transform.parent = null;
    }

    private void Heal()
    {
        hpScript.hp = hpScript.hp + healpoint;
        Debug.Log(healpoint + "回復");
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("回復当たってる");
        string hitObjectName = collision.gameObject.transform.root.name;
        if (hitObjectName == "リンゴ" || hitObjectName == "りんご")
        {
            if (calledOnce == true)
            {
                red = true;  //落ちてる2秒間回復量が増えないように。
                calledOnce = false;
                FallApple();
                Invoke("Heal", 2.0f);
            }
        }
    }
}
