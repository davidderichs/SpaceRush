using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{

    public float fullRotationTime;
    void Start()
    {

    }

    void Update()
    {
        transform.RotateAround(transform.position, transform.up, 360 * Time.deltaTime / fullRotationTime);
    }
}
