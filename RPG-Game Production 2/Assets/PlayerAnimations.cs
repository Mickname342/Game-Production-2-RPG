using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator animator;
    private PlayerMovementTutorial playerScript;
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        playerScript = GetComponent<PlayerMovementTutorial>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(playerScript.attackKey))
        {
            playerScript.swordCollider.enabled = true;
            animator.SetBool("Attacking", true);
        }
        else
        {
            
            animator.SetBool("Attacking", false);
        }

        if (playerScript.ApproachingGround && !playerScript.grounded)
        {
            animator.SetBool("ApproachingGround", true);
        }
        if (playerScript.grounded) { animator.SetBool("ApproachingGround", false); }
    }
}
