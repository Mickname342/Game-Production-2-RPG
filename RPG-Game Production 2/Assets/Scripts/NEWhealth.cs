using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NEWhealth : MonoBehaviour
{
    public GameObject splat1;
    public GameObject splat2;
    public GameObject splat3;
 //   public GameObject splat4;
 ///   public GameObject splat5;

    int health = 3;
 //   public float bounce = 5f;

    // Update is called once per frame
    void Update()
    {
        displayHealthState();

        switch (health)
        {
            case 0:
                {
                    splat1.gameObject.SetActive(false);
                    splat2.gameObject.SetActive(false);
                    splat3.gameObject.SetActive(false);
                   // splat4.gameObject.SetActive(false);
                 //   splat5.gameObject.SetActive(false);
                    break;
                }

            case 1:
                {
                    splat1.gameObject.SetActive(true);
                    splat2.gameObject.SetActive(false);
                    splat3.gameObject.SetActive(false);
                 //   splat4.gameObject.SetActive(false);
                 //   splat5.gameObject.SetActive(false);
                    break;
                }

            case 2:
                {
                    splat1.gameObject.SetActive(true);
                    splat2.gameObject.SetActive(true);
                    splat3.gameObject.SetActive(false);
                //    splat4.gameObject.SetActive(false);
                //    splat5.gameObject.SetActive(false);
                    break;
                }

            case 3:
                {
                    splat1.gameObject.SetActive(true);
                    splat2.gameObject.SetActive(true);
                    splat3.gameObject.SetActive(true);
                //    splat4.gameObject.SetActive(false);
                //    splat5.gameObject.SetActive(false);
                    break;
                }
                /*
            case 4:
                {
                    splat1.gameObject.SetActive(true);
                    splat2.gameObject.SetActive(true);
                    splat3.gameObject.SetActive(true);
                    splat4.gameObject.SetActive(true);
                    splat5.gameObject.SetActive(false);
                    break;
                }

            case 5:
                {
                    splat1.gameObject.SetActive(true);
                    splat2.gameObject.SetActive(true);
                    splat3.gameObject.SetActive(true);
                    splat4.gameObject.SetActive(true);
                    splat5.gameObject.SetActive(true);
                    break;
                }
                */
        }
    }

    void takeDamage()
    {
        health--;

    }

    void displayHealthState()
    {
        //DEAD
        if (health <= 0)
        {
            SceneManager.LoadScene(3);
            Debug.Log("YOU'RE DEAD");
        }

        if (health >= 3)
        {
            Debug.Log("FULL HEALTH");
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            takeDamage();
            Debug.Log("HURT");
        }
    }

    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //Bounce the player when making contact with enemy
            Vector3 direction = collision.gameObject.transform.position - gameObject.transform.position;
            gameObject.GetComponent<Rigidbody>().AddForce(collision.contacts[0].normal * bounce, ForceMode.Impulse);
        }
    }
    */
}
