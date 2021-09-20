using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItemScript : MonoBehaviour
{

    private GameObject player;
    PlayerHPBar2 hpScript;
    public float healpointGreen, healpointRed;
    private float healpoint;
    bool calledOnce, calledOnce2;
    public Material redMaterial;
    Vector3 AppleScal;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        hpScript = player.GetComponent<PlayerHPBar2>();
        calledOnce = true;
        calledOnce2 = true;
        AppleScal = this.gameObject.transform.localScale;


    }

    void Update()
    {
        if (calledOnce2 == true)
        {
            StartCoroutine("ChangeRed");
        }
    }

    private IEnumerator ChangeRed()
    {
        //10秒待機
        yield return new WaitForSeconds(40.0f);
        this.transform.localScale = new Vector3(200, 200, 200);
        GetComponent<Renderer>().material.color = redMaterial.color;
        calledOnce2 = false;
        //コルーチンを終了
        yield break;
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
        if (calledOnce2 == false)
        {
            healpoint = healpointRed;
        }
        else
        {
            healpoint = healpointGreen;
        }
        hpScript.hp = hpScript.hp + healpoint;
        calledOnce = false;
        Debug.Log(healpoint + "回復");
        Destroy(this.gameObject);

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("回復当たってる");
        if (GameObject.Find("FlyingText") != null)
        {
            if (GameObject.Find("リ") != null || GameObject.Find("り") != null)
            {
                if (GameObject.Find("ン") != null || GameObject.Find("ん") != null)
                {
                    if (GameObject.Find("ゴ") != null || GameObject.Find("ご") != null)
                    {
                        if (calledOnce == true)
                        {
                            FallApple();
                            Invoke("Heal", 2.0f);

                        }
                    }
                }
            }
        }
    }


}
