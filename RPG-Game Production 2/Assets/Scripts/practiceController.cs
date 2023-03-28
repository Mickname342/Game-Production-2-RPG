using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class practiceController : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            anim.SetBool("Walking", true);
        }  
        if (Input.GetKeyUp("p"))
        {
            anim.SetBool("Walking", false);
        } 
        if (Input.GetKeyDown("o"))
        {
            anim.SetBool("Idling", true);
        }  
        if (Input.GetKeyUp("o"))
        {
            anim.SetBool("Idling", false);
        }  
        if (Input.GetKeyDown("i"))
        {
            anim.SetBool("Running", true);
        }  
        if (Input.GetKeyUp("i"))
        {
            anim.SetBool("Running", false);
        } 
        if (Input.GetKeyDown("u"))
        {
            anim.SetBool("Attacking", true);
        }  
        if (Input.GetKeyUp("u"))
        {
            anim.SetBool("Attacking", false);
        }
    }
}
