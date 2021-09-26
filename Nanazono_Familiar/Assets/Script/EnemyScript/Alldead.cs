using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alldead : MonoBehaviour
{
    private Animator animator;  
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void dead()
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] enemysN = GameObject.FindGameObjectsWithTag("EnemyN");
        GameObject[] enemysT = GameObject.FindGameObjectsWithTag("EnemyT");
        Debug.Log("死んでるよ");
        Debug.Log(enemys.Length);
        for (int i = 0; i < enemys.Length; i++)
        {
            enemys[i].gameObject.GetComponent<Animator>().SetTrigger("Dead");              
        }
        for (int i = 0; i < enemysN.Length; i++)
        {
            enemysN[i].gameObject.GetComponent<Animator>().SetTrigger("Dead");
        }
        for (int i = 0; i < enemysT.Length; i++)
        {
            enemysT[i].gameObject.GetComponent<Animator>().SetTrigger("Dead");
        }
    }
}
