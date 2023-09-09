using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmellMeat : MonoBehaviour, IPickUp
{
    public void PickUp()
    {
        PlayerMove.instance.Reverse();
        Destroy(gameObject);
    }
}
