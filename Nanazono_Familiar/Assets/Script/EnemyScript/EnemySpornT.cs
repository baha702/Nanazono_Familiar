using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpornT : MonoBehaviour
{
    private GameObject _ars_normal;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindWithTag("EnemyT") == null)

            _ars_normal.gameObject.SetActive(true);
        animator.SetTrigger("Sporn");
    }

}