using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponActionCard : ActionCard {
 
	public WeaponActionCard(string description, string type, float fuelCost, string spriteName, Color color, float duration, float forceOrVelocity){
		this.description = description;
		this.type = type;
		this.fuelCost = fuelCost;
		this.spriteName = spriteName;
		this.color = color;
		this.duration = duration;
		this.forceOrVelocity = forceOrVelocity;
	}
	public static WeaponActionCard NewMove(WeaponActionCard action){
		string description = action.description;
		string type = action.type;
		float fuelCost = action.fuelCost;
		string spriteName = action.spriteName;
		Color color = action.color;
		float duration = action.duration;
		float forceOrVelocity = action.forceOrVelocity;
		return new WeaponActionCard(description,type,fuelCost,spriteName,color,duration,forceOrVelocity);
	}
}
