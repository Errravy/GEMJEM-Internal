using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounds : MonoBehaviour
{
    public static Grounds instance;
    public Transform frontGround;
    public float speed = 5f;
    public float length = 10f;

    private void Awake()
    {
        instance = this;
    }
    public void SetGround(Transform ground)
    {
        frontGround = ground;
    }
}
