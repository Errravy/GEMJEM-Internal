using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : MonoBehaviour, IPickUp
{
    public void PickUp()
    {
        GameManager.instance.MultiplyCoin();
        Destroy(gameObject);
    }
}
