using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour {
	public SpaceCraftControl spaceCraft;
	public int blevel1 = 100;
	public int blevel2 = 200;
	public int blevel3 = 300;
	public int bdir = 5;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
         if (Input.GetKeyDown(KeyCode.A)){
			 spaceCraft.AddBoost(SpaceCraftControl.Booster.FORWARD,blevel1);
		 }
		 if (Input.GetKeyDown(KeyCode.S)){
			 spaceCraft.AddBoost(SpaceCraftControl.Booster.FORWARD,blevel2);
		 }
		 if (Input.GetKeyDown(KeyCode.D)){
			 spaceCraft.AddBoost(SpaceCraftControl.Booster.FORWARD,blevel3);
		 }
		 if (Input.GetKeyDown(KeyCode.Y)){
			 spaceCraft.AddBoost(SpaceCraftControl.Booster.BACKWARD,blevel1);
		 }
		 if (Input.GetKeyDown(KeyCode.X)){
			 spaceCraft.AddBoost(SpaceCraftControl.Booster.BACKWARD,blevel2);
		 }
		 if (Input.GetKeyDown(KeyCode.C)){
			 spaceCraft.AddBoost(SpaceCraftControl.Booster.BACKWARD,blevel3);
		 }
		 //90° wende nach Rechts
		 if (Input.GetKeyDown(KeyCode.F)){
			 spaceCraft.AddBoost(SpaceCraftControl.Booster.LEFT, bdir);
		 }
		 // 90° wende nach Links
		 if (Input.GetKeyDown(KeyCode.G)){
			 spaceCraft.AddBoost(SpaceCraftControl.Booster.RIGHT, bdir);
			 
			 spaceCraft.AddBoost(SpaceCraftControl.Booster.LEFT, bdir);
		 }
	}

}
