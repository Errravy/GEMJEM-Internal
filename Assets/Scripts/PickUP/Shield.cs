using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour, IPickUp
{
    public void PickUp()
    {
        PlayerMove.instance.Shield();
        Destroy(gameObject);
    }
}
