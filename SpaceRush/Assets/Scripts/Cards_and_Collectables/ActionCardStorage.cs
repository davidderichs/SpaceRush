using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ActionCardStorage{
    public static MoveActionCard getForward(){
        return new MoveActionCard("Forward", "forward",1,"forward",new Color(1,1,1,1),2,100);
    }
    public static MoveActionCard getBackward(){
        return new MoveActionCard("Backward", "backward",1,"backward",new Color(1,1,1,1),2,100);
    }
    public static MoveActionCard getRotationLeft(){
        return new MoveActionCard("Right", "rotateRight",1,"Rotate_Left",new Color(1,1,1,1),2,5);
    }
    public static MoveActionCard getRotationRight(){
        return new MoveActionCard("Left", "rotateLeft",1,"Rotate_Right",new Color(1,1,1,1),2,5);
    }
    public static MoveActionCard getEmpty(){
        return new MoveActionCard("None","none",0,"none",new Color(1,1,1,1),2,0);
    }
}