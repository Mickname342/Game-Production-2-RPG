using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
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
}

