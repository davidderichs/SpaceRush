using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour {
	public SpacecraftController spacecraft;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
         if (Input.GetKeyDown(KeyCode.W)){
			 spacecraft.BoostForwards(10);
		 }
		 if (Input.GetKeyDown(KeyCode.S)){
			 spacecraft.BoostBackwards(10);
		 }
		 if (Input.GetKeyDown(KeyCode.A)){
			 spacecraft.Rotate(4,SpacecraftController.Direction.Left);
		 }
		 if (Input.GetKeyDown(KeyCode.D)){
			 spacecraft.Rotate(4,SpacecraftController.Direction.Right);
		 }
	}

}
