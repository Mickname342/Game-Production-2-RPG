using UnityEngine;

public class CannonBall : MonoBehaviour
{
    public float time = 5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }

        if (time <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Health>().currentHealth -= 2;
            Destroy(gameObject);
        }     
        if (collision.gameObject.tag == "Shield")
        {
            Debug.Log("Hit shield");
        }
    }
}
