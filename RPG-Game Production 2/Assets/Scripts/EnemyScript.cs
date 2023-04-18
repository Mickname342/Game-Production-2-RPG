using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private float timer = 5f;
    private float time;
    public bool hit;
    SkinnedMeshRenderer[] renderers;
    Color[] defaultColor;
    void Start()
    {
        renderers = GetComponentsInChildren<SkinnedMeshRenderer>();
        defaultColor = new Color[renderers.Length];
        time = timer;
        for (int i = 0; i < renderers.Length; i++)
        {
            defaultColor[i] = renderers[i].material.color;
        }
    }

    // Update is called once per frame
    void Update()
    {
        

        if (hit)
        {
            time -= Time.deltaTime;
            for(int i = 0; i < renderers.Length; i++)
            {
                renderers[i].material.color += new Color(255, 0, 0, 150);
            }
            
        } else {
            for (int i = 0; i < renderers.Length; i++)
            {
                renderers[i].material.color = defaultColor[i];
            }
        }
        if(time <= 0)
        {
            hit = false;
            time = timer;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SprayPaint"))
        {
            hit = true;
            print("Hit");
        }
    }
}
