using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorForButtons : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
