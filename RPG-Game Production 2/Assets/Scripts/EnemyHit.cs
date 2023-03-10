using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHit : MonoBehaviour
{
    public float EnemyHealth;
    public float swordHit;
    public float coolDown;
    private GameObject knife;

    // Start is called before the first frame update
    void Start()
    {
        knife = GameObject.FindWithTag("Dagger");
    }

    // Update is called once per frame
    void Update()
    {
        if(coolDown> 0)
        {
            coolDown -= Time.deltaTime;
        }

        if(EnemyHealth <= 0)
        {
            Debug.Log("dead");
            GetComponent<Animator>().enabled = false;
            GetComponent<NavMeshAgent>().enabled = false;
            GetComponent<EnemyAI>().enabled = false;
            GetComponent<EnemyHit>().enabled = false;
            knife.AddComponent<BoxCollider>();
            knife.AddComponent<Rigidbody>();
            knife.transform.SetParent(null);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("sword") && coolDown <= 0 && EnemyHealth > 0)
        {
            Debug.Log("Hit");
            EnemyHealth -= swordHit;
            coolDown += 1.0f;
        }
    }
}
