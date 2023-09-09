using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mud : MonoBehaviour, IPickUp
{
    public void PickUp()
    {
        GameManager.instance.RemoveCoin();
        Destroy(gameObject);
    }
}
