using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    public Collider swordCollider;

    private void DisableCollider()
    {
        swordCollider.enabled = false;
        GetComponent<Animator>().SetBool("Attacking", false);
    }
}
