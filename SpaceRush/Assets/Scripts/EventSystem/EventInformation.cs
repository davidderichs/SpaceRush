using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventInformation : MonoBehaviour {

	private int id;
	private string description;

	public EventInformation(int id, string description){
		this.id = id;
		this.description = description;
	}

	public string toString(){
		string s = "Event.id: " + this.id + " Event.description: " + this.description;
		return s;
	}
}
