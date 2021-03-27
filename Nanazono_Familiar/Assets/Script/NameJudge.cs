using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameJudge : MonoBehaviour
{
    public GameObject enemyName1;
    public GameObject enemyName2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //[FlyingText]っていう名前のオブジェクトがあったら
        if (GameObject.Find("FlyingText") != null)
        {
            GameObject JudgeText = GameObject.Find("FlyingText");
            if (GameObject.Find("ト") != null)
            {
                GameObject childA = JudgeText.transform.Find("ト").gameObject;//FlyingTextの子の「ト」という名前のオブジェクトを探して変数childAに入れる
                childA.GetComponent<BoxCollider>().isTrigger = true;
                Debug.Log("ト！！！");
                enemyName1.gameObject.SetActive(true);
            }
        }
        if (GameObject.Find("FlyingText") != null)
        {
            GameObject JudgeText = GameObject.Find("FlyingText");
            if (GameObject.Find("ム") != null)
            {
                GameObject childB = JudgeText.transform.Find("ム").gameObject;//FlyingTextの子の「ト」という名前のオブジェクトを探して変数childAに入れる
                childB.GetComponent<BoxCollider>().isTrigger = true;
                Debug.Log("ム！！！");
                enemyName2.gameObject.SetActive(true);
            }
        }
    }
}
