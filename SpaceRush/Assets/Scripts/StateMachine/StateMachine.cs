using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour {
	private int state;

	void Start () 
	{
			state = 1;
	}

	void nextState()
	{
		if(state == 3)
		{
			state = 1;
		}
		else
		{	
			state++;
		}
		Debug.Log("State changed.");
	}
}
