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
    public GameObject enemyDrop;

    private EnemyScript enemyScript;
    private float multiplierDamage;

    // Start is called before the first frame update
    void Start()
    {
        knife = GameObject.FindWithTag("Dagger");
        enemyScript = GetComponent<EnemyScript>();
        multiplierDamage = swordHit * 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (coolDown > 0)
        {
            coolDown -= Time.deltaTime;
        }

        if (EnemyHealth <= 0)
        {
            Debug.Log("dead");
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 90);
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z);
            GetComponent<Animator>().enabled = false;
            GetComponent<NavMeshAgent>().enabled = false;
            GetComponent<EnemyAI>().enabled = false;
            GetComponent<EnemyHit>().enabled = false;
            knife.AddComponent<BoxCollider>();
            knife.AddComponent<Rigidbody>();
            knife.transform.SetParent(null);
            GameObject droppedItem = Instantiate(enemyDrop, transform.position + new Vector3(0, 0, 3), transform.rotation);

        }

        if (enemyScript.hit)
        {
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("sword") && coolDown <= 0 && EnemyHealth > 0)
        {
            Debug.Log("Hit");
            if (!enemyScript.hit)
            {
                EnemyHealth -= swordHit;
            }
            else
            {
                EnemyHealth -= multiplierDamage;
            }
            coolDown += 1.0f;
        }
    }

    
}
