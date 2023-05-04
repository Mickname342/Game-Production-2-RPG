using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    NavMeshAgent navAgent;
    public GameObject knife;
    public float Pdist;
    private float attackCoolDown;
    public float attackCoolDownFull;

    private Transform Player;
    public Transform[] wayP;

    int wayIndex;

    Vector3 target;

    private Animator anim;
    private Collider DagCol;
    void Start()
    {
        Player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        anim = GetComponent<Animator>();
        //get the component reference
        navAgent = GetComponent<NavMeshAgent>();
        //navAgent.destination = wayP.position;
        UpdateDestination();
        DagCol = knife.GetComponent<Collider>();
    }
    void Update()
    {
        if(attackCoolDown >= 0)
        {
            attackCoolDown -= Time.deltaTime;
        }

        if(Vector3.Distance(transform.position, target) < 2f)
        {
            IterateWaypointIndex();
            UpdateDestination();
        }

        Pdist = Vector3.Distance(transform.position, Player.position);
        if(Pdist <= 10f && Pdist >= 2f)
        {
            navAgent.destination = Player.position;
            anim.SetBool("Attacking", false);
            anim.SetBool("Running", true);
        }
        if (Pdist <= 2f)
        {
            Attack();
        }
        if(Pdist >= 10f)
        {
            navAgent.destination = target;
            anim.SetBool("Walking", true);
            anim.SetBool("Running", false);
        }
        else
        {
            anim.SetBool("Walking", false);
        }

        /*if (anim.GetCurrentAnimatorStateInfo(0).IsName("attack"))
        {
            DagCol.enabled = true;
        }
        else
        {
            DagCol.enabled = false;
        }*/
    }
    private void UpdateDestination()
    {
        target = wayP[wayIndex].position;
        navAgent.destination = target;
    }
    void IterateWaypointIndex()
    {
        wayIndex++;
        if(wayIndex == wayP.Length)
        {
            wayIndex= 0;
        }
    }

    void Attack()
    {
       // transform.LookAt(Player);
        navAgent.destination = transform.position;
        anim.SetBool("AttackIdle", true);
        anim.SetBool("Running", false);
        if(attackCoolDown <= 0)
        {
            anim.SetBool("AttackIdle", false);
            anim.SetBool("Attacking", true);
            attackCoolDown = attackCoolDownFull;
        }
        else if (attackCoolDown >= 0)
        {
            anim.SetBool("Attacking", false);
            anim.SetBool("AttackIdle", true);
        }

    }


}
