using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrustersController : MonoBehaviour
{
    public GameObject forwardsBoosters;
    public GameObject backwardsBoosters;
    private ParticleSystem[] forwardsBoosterSystems;
    private ParticleSystem[] backwardsBoosterSystems;

    // Use this for initialization
    void Start()
    {
        forwardsBoosterSystems = forwardsBoosters.GetComponentsInChildren<ParticleSystem>();
        backwardsBoosterSystems = backwardsBoosters.GetComponentsInChildren<ParticleSystem>();
        StopBoost();
    }

    public void Boost(SpacecraftAction.Direction direction)
    {
        switch (direction)
        {
            case SpacecraftAction.Direction.Forwards:
                ActivateForwardsBoosters();
                return;
            case SpacecraftAction.Direction.Backwards:
                ActivateBackwardsBoosters();
                return;
        }
    }

    public void StopBoost()
    {
        foreach (ParticleSystem system in forwardsBoosterSystems)
        {
            system.Stop();
        }
        foreach (ParticleSystem system in backwardsBoosterSystems)
        {
            system.Stop();
        }
    }

    private void ActivateForwardsBoosters()
    {
        foreach (ParticleSystem system in forwardsBoosterSystems)
        {
            system.Play();
        }
    }

    private void ActivateBackwardsBoosters()
    {
        foreach (ParticleSystem system in backwardsBoosterSystems)
        {
            system.Play();
        }
    }
}
