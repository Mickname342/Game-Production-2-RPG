using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldUp : MonoBehaviour
{
    public Animator anim;
    public bool shielding;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            anim.SetBool("shieldUp", true);
            shielding = true;
        }
        if (Input.GetButtonUp("Fire2"))
        {
            anim.SetBool("shieldUp", false);
            shielding = false;
        }

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Dagger"))
        {

            Debug.Log("blocked");
        }
    }
}
