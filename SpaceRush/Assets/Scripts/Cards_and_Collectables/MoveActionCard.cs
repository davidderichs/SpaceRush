using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveActionCard : ActionCard {

	public MoveActionCard(string description, string type, float fuelCost, string spriteName, Color color, float duration, float forceOrVelocity){
		this.description = description;
		this.type = type;
		this.fuelCost = fuelCost;
		this.spriteName = spriteName;
		this.color = color;
		this.duration = duration;
		this.forceOrVelocity = forceOrVelocity;
	}
}
