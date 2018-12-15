using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpacecraftCollisionListener
{
    void OnSpacecraftCollision(Spacecraft spacecraft, GameObject collider);
}

