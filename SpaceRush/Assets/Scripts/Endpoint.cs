using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endpoint : MonoBehaviour {
	public Vector3 position;

	// Use this for initialization
	void Start() {
		position = transform.position;
	}
	void OnTriggerEnter(Collider other)
    {
		Light point = GetComponent<Light>();
		point.color = Color.green;
    }
}