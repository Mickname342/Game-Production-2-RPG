using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    public float EnemyHealth;
    public float swordHit;
    public float coolDown;

    // Start is called before the first frame update
    void Start()
    {
        
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
