using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyWalk : MonoBehaviour
{
    protected NavMeshAgent agent;
    protected float defaultMoveSpeed;
    private Animator animator;
    protected Transform target;
    public float MoveSpeed { set; get; }
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        defaultMoveSpeed = agent.speed;
        MoveSpeed = defaultMoveSpeed;
    }
  protected virtual void Update()
    {
        if (target != null)
        {
            agent.speed = MoveSpeed;

            Move();
        }
    }
    // Update is called once per frame
    protected virtual void Move()
    {
        animator.SetFloat("Walk", agent.speed, 0.5f, Time.deltaTime);


    }
    protected void ResetMoveSpeed()
    {
        MoveSpeed = defaultMoveSpeed;
    }
}


