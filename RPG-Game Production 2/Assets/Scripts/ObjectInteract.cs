using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteract : MonoBehaviour
{
    public GameObject ClueUI;
    public GameObject InteractUI;
    private bool UIActive = false;

    private PlayerMovementTutorial PlayerScript;

    private GameObject cam;
    private GameObject itemHit = null;

    // Reach distance for interacting with objects
    [SerializeField] private float rayMax = 10f;

    [SerializeField] private LayerMask ItemMask;

    private void Start()
    {
        cam = GameObject.FindWithTag("MainCamera");
        PlayerScript = GameObject.FindWithTag("Player").GetComponent<PlayerMovementTutorial>();
    }

    private void Update()
    {
        bool ray = Physics.Raycast(cam.transform.position, cam.transform.forward, rayMax, ItemMask, QueryTriggerInteraction.Ignore);
        RaycastHit[] rays = Physics.RaycastAll(cam.transform.position, cam.transform.forward, rayMax, ItemMask, QueryTriggerInteraction.Ignore);

        for (int i = 0; i < rays.Length; i++)
        {
            RaycastHit hit = rays[i];
            itemHit = hit.transform.gameObject;
        }

        if (ray && itemHit != null)
        {
            itemHit.GetComponent<Outline>().enabled = true;
            InteractUI.SetActive(true);
            if (Input.GetKeyDown(PlayerScript.interactKey))
            {
                UIActive = !UIActive;
                if (UIActive)
                {
                    ClueUI.SetActive(true);
                } else
                {
                    ClueUI.SetActive(false);
                }
            }
        }
        if (!ray && itemHit != null)
        {
            if (UIActive)
            {
                UIActive = !UIActive;
                ClueUI.SetActive(false);
            }
            InteractUI.SetActive(false);
            itemHit.GetComponent<Outline>().enabled = false;
            itemHit = null;
        }
        if (itemHit == null && !ray)
        {
            if (UIActive)
            {
                UIActive = !UIActive;
                ClueUI.SetActive(false);
            }
            InteractUI.SetActive(false);
            StopOutline();
        }
        //Debug.DrawRay(cam.transform.position, cam.transform.forward * 100, Color.red);
    }

    private void StopOutline()
    {
        GameObject[] Outlined = GameObject.FindGameObjectsWithTag("Item");
        for (int i = 0; i < Outlined.Length; i++)
        {
            Outlined[i].gameObject.GetComponent<Outline>().enabled = false;
        }
    }
}
