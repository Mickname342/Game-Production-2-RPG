using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PaintingsCollected : MonoBehaviour
{
    int paintingsLeft = 10;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        paintingsLeft = transform.childCount;

        if(paintingsLeft <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }
}
