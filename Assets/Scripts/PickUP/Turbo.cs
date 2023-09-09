using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turbo : MonoBehaviour, IPickUp
{
    public void PickUp()
    {
        GameManager.instance.Turbo();
        Destroy(gameObject);
    }
}
