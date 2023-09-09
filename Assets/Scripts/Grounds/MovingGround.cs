using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingGround : MonoBehaviour
{
    private void Update()
    {
        BackToPosition();
        Move();
    }

    private void Move()
    {
        transform.position += -Vector3.forward * Grounds.instance.speed * Time.deltaTime;
    }

    private void BackToPosition()
    {

        if (transform.position.z <= -32.9)
        {
            transform.position = Grounds.instance.frontGround.position + Vector3.forward * Grounds.instance.length;
            Grounds.instance.SetGround(transform);
        }
    }
}
