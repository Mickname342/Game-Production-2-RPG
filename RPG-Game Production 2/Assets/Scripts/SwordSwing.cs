using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSwing : MonoBehaviour
{
    public Animator anim;

    public Collider swordCol;

    public float coolDown;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(coolDown >= 0)
        {
            coolDown -= Time.deltaTime;
            swordCol.enabled = true;
        }
        else
        {
            swordCol.enabled = false;
        }

        if (Input.GetButtonDown("Fire1") && coolDown <= 0)
        {
            Swing();
            coolDown = 1;
        }
    }

    void Swing()
    {
        if(coolDown <= 0)
        {
            anim.Play("sword Swing");
        }
    }
}
