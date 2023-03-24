using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontDestroyAudio : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
