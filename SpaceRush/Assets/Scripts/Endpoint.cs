using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endpoint : MonoBehaviour
{
    public Vector3 position;
    private Light pointLight;

    void Start()
    {
        position = transform.position;
        pointLight = GetComponent<Light>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        pointLight.color = Color.green;
    }
}