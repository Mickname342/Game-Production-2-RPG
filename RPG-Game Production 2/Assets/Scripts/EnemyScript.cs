using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private float timer = 5f;
    private float time;
    private bool hit;
    MeshRenderer renderer;
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        time = timer;   
    }

    // Update is called once per frame
    void Update()
    {
        if (hit)
        {
            time -= Time.deltaTime;
            renderer.material.color = Color.red;
        } else { renderer.material.color = Color.white; }
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
