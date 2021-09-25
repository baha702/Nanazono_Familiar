using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alldead : MonoBehaviour
{
    private GameObject demobon_Str2;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindWithTag("EnemyBoss") == null)
            demobon_Str2.gameObject.SetActive(false);
        animator.SetTrigger("Dead");
        Destroy(this.gameObject);
    }
}
