using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject cannonBall;
    public float cannonBallSpeed = 20;
    public Transform firePos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _Fire();
        }
    }

    private void _Fire()
    {
        GameObject Ball = Instantiate(cannonBall, firePos.position, Quaternion.identity);

        Rigidbody rb = Ball.GetComponent<Rigidbody>();
        rb.velocity = cannonBallSpeed * firePos.forward;
    }
}
