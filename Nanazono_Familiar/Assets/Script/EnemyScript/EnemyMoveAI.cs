using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveAI : MonoBehaviour
{
    // 目的地となるGameObjectをセットします。
    public GameObject target;
    private NavMeshAgent myAgent;

    void Start()
    {
        // Nav Mesh Agent を取得します。
        myAgent = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Target");
    }

    void Update()
    {
        // targetに向かって移動します。
        myAgent.SetDestination(target.transform.position);
    }
}
