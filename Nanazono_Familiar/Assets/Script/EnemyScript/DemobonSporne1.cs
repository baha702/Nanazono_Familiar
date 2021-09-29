using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemobonSporne1 : MonoBehaviour
{
    private Animator animator;
    public GameObject reticle;
    StageChange stagechange;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        stagechange = reticle.GetComponent<StageChange>();
    }

    private void Update()
    {
        if (stagechange.demobonsporn)
        {
            animator = GetComponent<Animator>();
            animator.SetTrigger("Sporn");
        }
    }

    
}
