using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardParser
{
    public static SpacecraftMovement ParseCard(MoveCard card)
    {
        float forceOrVelocity = card.forceOrVelocity;
        float duration = card.duration;
        SpacecraftMovement.Direction direction = SpacecraftMovement.Direction.None;
        switch (card.direction)
        {
            case "forward":
                direction = SpacecraftMovement.Direction.Forwards;
                break;
            case "backward":
                direction = SpacecraftMovement.Direction.Backwards;
                break;
            case "Rotate_Left":
                direction = SpacecraftMovement.Direction.Left;
                break;
            case "Rotate_Right":
                direction = SpacecraftMovement.Direction.Right;
                break;
        }
        switch (card.kind_Of_Movement)
        {
            case "boost":
                return new SpacecraftBoost(direction, forceOrVelocity, duration);
            case "rotate":
                return new SpacecraftRotation(direction, forceOrVelocity, duration);
        }
        return null;
    }
}
