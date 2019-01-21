using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacecraftWeaponAction : SpacecraftAction
{
    public enum WeaponType { GravityMine, Rocket, Laser }
    public WeaponType type;

    public SpacecraftWeaponAction(WeaponType type)
    {
        this.type = type;
    }
}
