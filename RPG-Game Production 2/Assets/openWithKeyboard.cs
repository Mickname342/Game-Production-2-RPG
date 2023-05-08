using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openWithKeyboard : MonoBehaviour
{
    public AudioSource audio;

    public GameObject gameMenu, gameInventory;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && gameMenu.activeInHierarchy == false)
        {
            gameMenu.SetActive(true);

            audio.Play();

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && gameMenu.activeInHierarchy == true)
        {
            gameMenu.SetActive(false);

            audio.Play();

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        if (Input.GetKeyDown(KeyCode.I) && gameInventory.activeInHierarchy == false)
        {
            gameInventory.SetActive(true);

            audio.Play();

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if(Input.GetKeyDown(KeyCode.I) && gameInventory.activeInHierarchy == true)
        {
            gameInventory.SetActive(false);

            audio.Play();

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
