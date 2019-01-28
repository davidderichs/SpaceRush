using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu_Orbiter : MonoBehaviour {

	public Vector3 targetPosition;

	public Vector3 rotationVector;

	public Vector3 selfRotationVector;


	// Use this for initialization
	void Start () {
		targetPosition = new Vector3(60,-33,0);
		rotationVector = new Vector3 (0, 0, 1);
		selfRotationVector = Vector3.forward;
	}
	
	// Update is called once per frame
    void FixedUpdate() {
        this.transform.RotateAround(targetPosition, rotationVector, 10 * Time.deltaTime);
		this.transform.Rotate(selfRotationVector, 1 * Time.deltaTime);
    }
}
