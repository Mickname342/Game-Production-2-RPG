using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldUp : MonoBehaviour
{
    public Animator anim;
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
        }
        if (Input.GetButtonUp("Fire2"))
        {
            anim.SetBool("shieldUp", false);
        }

    }
}
