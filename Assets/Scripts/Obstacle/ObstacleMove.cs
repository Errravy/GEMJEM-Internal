using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 60);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += -Vector3.forward * Grounds.instance.speed * Time.deltaTime;
    }
}
