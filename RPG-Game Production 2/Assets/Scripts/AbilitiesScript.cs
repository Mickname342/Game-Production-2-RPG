using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AbilitiesScript : MonoBehaviour
{
    PlayerMovementTutorial playerMovement;
    public BoxCollider box;
    private bool CanUse = true;
    [SerializeField] private float timer = 10f;
    private float time;
    private bool Spray;
    void Start()
    {
        playerMovement = GetComponent<PlayerMovementTutorial>();
        time = timer;
    }

    void Update()
    {
        SprayPaint();
        
        if (!CanUse && time > 0)
        {
            time -= Time.deltaTime;
        }
        if(time <= 4)
        {
            Spray = false;
        }
        if (time <= 0)
        {
            CanUse = true;
            time = timer;
            print("CanUse");
        }
    }

    private void SprayPaint()
    {
        if (Input.GetKeyDown(playerMovement.drawKey) && CanUse)
        {
            CanUse = false;
            Spray = true;
        }
        if (Spray)
        {
            box.enabled = true;
        } else { box.enabled = false; }
    }
}
