using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour, IPickUp
{
    public void PickUp()
    {
        GameManager.instance.ReverseCamera();
        Destroy(gameObject);
    }
}
