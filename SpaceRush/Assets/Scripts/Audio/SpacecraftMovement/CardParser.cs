using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardParser
{
    public static SpacecraftMovement ParseCard(MoveCard card)
    {/* 
        float forceOrVelocity = card.force;
        float duration = card.duration;
        SpacecraftMovement.Direction direction = SpacecraftMovement.Direction.None;
        switch (card.direction)
        {
            case "forwards":
                direction = SpacecraftMovement.Direction.Forwards;
                break;
            case "backwards":
                direction = SpacecraftMovement.Direction.Backwards;
                break;
            case "left":
                direction = SpacecraftMovement.Direction.Left;
                break;
            case "right":
                direction = SpacecraftMovement.Direction.Right;
                break;
        }
        switch (card.kind_Of_Movement)
        {
            case "boost":
                return new SpacecraftBoost(direction, forceOrVelocity, duration);
                break;
            case "rotate":
                return new SpacecraftRotation(direction, forceOrVelocity, duration);
                break;
		}*/
        return null;
    }
}
