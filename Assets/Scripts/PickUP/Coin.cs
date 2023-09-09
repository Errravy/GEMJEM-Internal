using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, IPickUp
{
    public void PickUp()
    {
        GameManager.instance.AddCoin();
        Destroy(gameObject);
    }
}
