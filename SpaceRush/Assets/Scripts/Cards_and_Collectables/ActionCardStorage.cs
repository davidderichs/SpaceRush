using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ActionCardStorage{
    /*this.description = description;
		this.direction = direction;
		this.fuelCost = fuelCost;
		this.spriteName = spriteName;
		this.color = color;
		this.kindOfMovement = kindOfMovement;
		this.duration = duration;
		this.forceOrVelocity = forceOrVelocity; */
    public static MoveActionCard getForward(){
        return new MoveActionCard("Forward", "forward",1,"forward",new Color(1,1,1,1),2,300);
    }
    public static MoveActionCard getBackward(){
        return new MoveActionCard("Backward", "backward",1,"backward",new Color(1,1,1,1),2,300);
    }
    public static MoveActionCard getRotationLeft(){
        return new MoveActionCard("Right", "rotateRight",1,"forward",new Color(1,1,1,1),2,300);
    }
    public static MoveActionCard getRotationRight(){
        return new MoveActionCard("Left", "rotateLeft",1,"forward",new Color(1,1,1,1),2,300);
    }
    public static MoveActionCard getEmpty(){
        return new MoveActionCard("None","none",0,"none",new Color(1,1,1,1),2,0);
    }
}