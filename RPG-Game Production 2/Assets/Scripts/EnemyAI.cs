using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    NavMeshAgent navAgent;
    public GameObject knife;
    public float Pdist;

    public Transform Player;
    public Transform[] wayP;

    int wayIndex;

    Vector3 target;

    private Animator anim;
    private Collider DagCol;
    void Start()
    {
        anim= GetComponent<Animator>();
        //get the component reference
        navAgent = GetComponent<NavMeshAgent>();
        //navAgent.destination = wayP.position;
        UpdateDestination();
        DagCol = knife.GetComponent<Collider>();
    }
    void Update()
    {
        if(Vector3.Distance(transform.position, target) < 1f)
        {
            IterateWaypointIndex();
            UpdateDestination();
        }

        Pdist = Vector3.Distance(transform.position, Player.position);
        if(Pdist <= 7.5f && Pdist >= 2f)
        {
            navAgent.destination = Player.position;
            anim.SetBool("Attack", false);
        }
        if (Pdist <= 2f)
        {
            Attack();
        }
        if(Pdist >= 7.5f)
        {
            navAgent.destination = target;
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("attack"))
        {
            DagCol.enabled = true;
        }
        else
        {
            DagCol.enabled = false;
        }
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
        navAgent.destination = transform.position;
        anim.SetBool("Attack", true);
    }


}
