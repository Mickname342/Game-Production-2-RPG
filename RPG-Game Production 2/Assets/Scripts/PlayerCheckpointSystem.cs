using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckpointSystem : MonoBehaviour
{
    public Transform startPostition;
    public Transform checpoint1;
    public Transform checpoint2;
    Transform currentCheckpoint;


    void Start()
    {
        currentCheckpoint = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetChecpoint1()
    {
        currentCheckpoint = checpoint1;
        print("something");
    }

    public void SetChecpoint2()
    {
        currentCheckpoint = checpoint2;
    }

    public void ReturnToChecpoint()
    {
        transform.position = currentCheckpoint.position - new Vector3(0,0,0);
    }
}
