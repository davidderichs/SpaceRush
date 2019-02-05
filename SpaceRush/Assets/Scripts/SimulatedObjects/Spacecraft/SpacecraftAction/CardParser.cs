using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardParser
{
    public static SpacecraftAction ParseCard(ActionCard card)
    {
        //Debug.Log(card.type);
        if (card.type.Equals("forward") || card.type.Equals("backward"))
        {
            SpacecraftAction.Direction direction = SpacecraftAction.Direction.None;
            switch (card.type)
            {
                case "forward":
                    direction = SpacecraftAction.Direction.Forwards;
                    break;
                case "backward":
                    direction = SpacecraftAction.Direction.Backwards;
                    break;
            }
            float force = card.forceOrVelocity;
            float duration = card.duration;
            float fuelCost = card.fuelCost;
            return new SpacecraftBoost(direction, fuelCost, force, duration);
        }
        else if (card.type.Contains("rotate"))
        {
            SpacecraftAction.Direction direction = SpacecraftAction.Direction.None;
            switch (card.type)
            {
                case "rotateLeft":
                    direction = SpacecraftAction.Direction.Left;
                    break;
                case "rotateRight":
                    direction = SpacecraftAction.Direction.Right;
                    break;
            }
            float velocity = card.forceOrVelocity;
            float duration = card.duration;
            float fuelCost = 1;
            return new SpacecraftRotation(direction, fuelCost, velocity, duration);
        }
        else if (card.type.Equals("gravityMine"))
        {
            return new SpacecraftWeaponAction(SpacecraftWeaponAction.WeaponType.GravityMine, card.fuelCost);
        }
        else if (card.type.Equals("laser"))
        {
            return new SpacecraftWeaponAction(SpacecraftWeaponAction.WeaponType.Laser, card.fuelCost);
        }
        else if (card.type.Equals("rocket"))
        {
            return new SpacecraftWeaponAction(SpacecraftWeaponAction.WeaponType.Rocket, card.fuelCost);
        }
        return null;
    }
}
