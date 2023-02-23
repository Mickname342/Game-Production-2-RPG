using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;
    public float bounce = 5f;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {

    }

    void takeDamage(int amount)
    {
        currentHealth -= amount;

        if(currentHealth <= 0)
        {
            Debug.Log("Game Over!");
        }
    }

    void Heal(int amount)
    {
        currentHealth += amount;

        if (currentHealth > maxHealth)
        {
            Debug.Log("Healing!");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Vector3 direction = collision.gameObject.transform.position - gameObject.transform.position;
            takeDamage(3);
            gameObject.GetComponent<Rigidbody>().AddForce(collision.contacts[0].normal * bounce, ForceMode.Impulse);
        }
    }
}

