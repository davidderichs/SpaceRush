using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardParser
{
    public static SpacecraftAction ParseCard(MoveCard card)
    {
        if (card.kind_Of_Movement.Equals("boost"))
        {
            SpacecraftAction.Direction direction = SpacecraftAction.Direction.None;
            switch (card.direction)
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
            return new SpacecraftBoost(direction, force, duration);
        }
        else if (card.kind_Of_Movement.Equals("rotate"))
        {
            SpacecraftAction.Direction direction = SpacecraftAction.Direction.None;
            switch (card.direction)
            {
                case "Rotate_Left":
                    direction = SpacecraftAction.Direction.Left;
                    break;
                case "Rotate_Right":
                    direction = SpacecraftAction.Direction.Right;
                    break;
            }
            float velocity = card.forceOrVelocity;
            float duration = card.duration;
            return new SpacecraftRotation(direction, velocity, duration);
        }
        else if (card.kind_Of_Movement.Equals("gravityMine"))
        {
            return new SpacecraftWeaponAction(SpacecraftWeaponAction.WeaponType.GravityMine);
        }
        else if (card.kind_Of_Movement.Equals("laser"))
        {
            return new SpacecraftWeaponAction(SpacecraftWeaponAction.WeaponType.Laser);
        }
        else if (card.kind_Of_Movement.Equals("rocket"))
        {
            return new SpacecraftWeaponAction(SpacecraftWeaponAction.WeaponType.Rocket);
        }
        return null;
    }
}
