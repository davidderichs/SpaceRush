using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ActionCardStorage{
    public static MoveActionCard GetForward(){
        return new MoveActionCard("Forward", "forward",1,"forward",new Color(1,1,1,1),2,100);
    }
    public static MoveActionCard GetBackward(){
        return new MoveActionCard("Backward", "backward",1,"backward",new Color(1,1,1,1),2,100);
    }
    public static MoveActionCard GetRotationLeft(){
        return new MoveActionCard("Left", "rotateRight",1,"Rotate_Left",new Color(1,1,1,1),2,5);
    }
    public static MoveActionCard GetRotationRight(){
        return new MoveActionCard("Right", "rotateLeft",1,"Rotate_Right",new Color(1,1,1,1),2,5);
    }
    public static MoveActionCard GetEmpty(){
        return new MoveActionCard("None","none",0,"none",new Color(1,1,1,1),2,0);
    }
    public static WeaponActionCard GetGravityMine(){
        return new WeaponActionCard("Gravitymine","gravityMine",3,"WeaponGravityMine",new Color(1,1,1,1),2,0);
    }
    public static WeaponActionCard GetRocket(){
        return new WeaponActionCard("Rocket","rocket",3,"WeaponRocket",new Color(1,1,1,1),2,0);
    }
    public static WeaponActionCard GetLaser(){
        return new WeaponActionCard("Laser","laser",3,"WeaponLaser",new Color(1,1,1,1),2,0);
    }
}