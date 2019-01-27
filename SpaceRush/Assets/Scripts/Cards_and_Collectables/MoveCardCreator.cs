using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCardCreator : MonoBehaviour
{

    public static MoveCard getForward()
    {
        MoveCard card = new MoveCard("forward", 3, new Color(1, 1, 1, 1), true, "Sprites/", "boost", 2, 300);
        return card;
    }

    public static MoveCard getBackward()
    {
        MoveCard card = new MoveCard("backward", 3, new Color(1, 1, 1, 1), true, "Sprites/", "boost", 2, 300);
        return card;
    }
    public static MoveCard getRotationRight30()
    {
        MoveCard card = new MoveCard("Rotate_Right", 3, new Color(1, 1, 1, 1), true, "Sprites/", "rotate", 2, 15);
        return card;
    }
    public static MoveCard getRotationLeft30()
    {
        MoveCard card = new MoveCard("Rotate_Left", 3, new Color(1, 1, 1, 1), true, "Sprites/", "rotate", 2, 15);
        return card;
    }

    public static MoveCard getRotationRight60()
    {
        MoveCard card = new MoveCard("Rotate_Right", 3, new Color(1, 1, 1, 1), true, "Sprites/", "rotate", 2, 30);
        return card;
    }

    public static MoveCard getRotationLeft60()
    {
        MoveCard card = new MoveCard("Rotate_Left", 3, new Color(1, 1, 1, 1), true, "Sprites/", "rotate", 2, 30);
        return card;
    }

    public static MoveCard getRotationRight90()
    {
        MoveCard card = new MoveCard("Rotate_Right", 3, new Color(1, 1, 1, 1), true, "Sprites/", "rotate", 2, 45);
        return card;
    }

    public static MoveCard getRotationLeft90()
    {
        MoveCard card = new MoveCard("Rotate_Left", 3, new Color(1, 1, 1, 1), true, "Sprites/", "rotate", 2, 45);
        return card;
    }

	public static MoveCard getWeapon(string weaponName){
		switch(weaponName){
			case "Weapon_Laser": return getWeaponLaser();
			case "Weapon_Gravity_Mine": return getWeaponGravityMine();
			default: return getRotationRight90();
		}
	}


	private static MoveCard getWeaponLaser()
    {
        MoveCard card = new MoveCard("Weapon_Laser", 3, new Color(1, 1, 1, 1), true, "Sprites/", "laser", 2, 30);
        return card;
    }

	private static MoveCard getWeaponGravityMine()
    {
        MoveCard card = new MoveCard("Weapon_Gravity_Mine", 3, new Color(1, 1, 1, 1), true, "Sprites/", "gravityMine", 2, 30);
        return card;
    }
}
