using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemPickUp : MonoBehaviour
{
    public Item Item;

    void PickUp()
    {
        InevntoryManager.Instance.Add(Item);
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        PickUp();
    }
}
