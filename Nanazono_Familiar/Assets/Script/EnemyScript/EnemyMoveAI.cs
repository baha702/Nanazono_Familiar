using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;


public class EnemyMoveAI : MonoBehaviour
{
    // 目的地となるGameObjectをセットします。
    public GameObject target;
    private NavMeshAgent myAgent;
    public float speed=0;
    public int length;
    [SerializeField] TextMeshProUGUI[] enemyTMP;
    public Material blueMate;
    NameJudge namejudge;

    void Start()
    {
        // Nav Mesh Agent を取得します。
        myAgent = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Target");
        speed = 2.0f;
        
    }

    void Update()
    {
        myAgent.speed = speed;
        // targetに向かって移動します。
        myAgent.SetDestination(target.transform.position);
        /*if (namejudge.enespeed<=0)
        {
            Coroutine();
        }*/
    }

    private IEnumerator Coroutine()
    {
        Debug.Log("コルーチン");
        //１秒待機
        yield return new WaitForSeconds(1.0f);
        speed = 2.0f;
        //コルーチンを終了
        yield break;
    }

   
}
