using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacecraftControllerTester : MonoBehaviour
{

    public SpacecraftController controller;
    public float timer;
    public ArrayList spacecraftManeuvers;

    void OnEnable()
    {
        controller = GetComponent<SpacecraftController>();
        timer = 0;
        spacecraftManeuvers = new ArrayList();

        spacecraftManeuvers.Add(new SpacecraftManeuverAction("forwards", 1, 3, this));
        spacecraftManeuvers.Add(new SpacecraftManeuverAction("backwards", 6, 3, this));
        spacecraftManeuvers.Add(new SpacecraftManeuverAction("backwards", 12, 4, this));
        spacecraftManeuvers.Add(new SpacecraftManeuverAction("forwards", 18, 4, this));

        spacecraftManeuvers.Add(new SpacecraftManeuverAction("rotateLeft", 2, 2, this));
        spacecraftManeuvers.Add(new SpacecraftManeuverAction("rotateRight", 6, 2, this));
    }

    void Update()
    {
        timer += Time.deltaTime;
        for (int i = spacecraftManeuvers.Count - 1; i >= 0; i--)
        {
            SpacecraftManeuverAction current = (SpacecraftManeuverAction)spacecraftManeuvers[i];
            current.check();
        }
    }
}

public class SpacecraftManeuverAction
{
    public float startTime;
    public string maneuver;
    public float time;
    public SpacecraftControllerTester parent;

    public SpacecraftManeuverAction(string maneuver, float startTime, float boostTime, SpacecraftControllerTester parent)
    {
        this.startTime = startTime;
        this.maneuver = maneuver;
        this.time = boostTime;
        this.parent = parent;
    }

    public void check()
    {
        if (parent.timer >= startTime)
        {
            switch (maneuver)
            {
                case "forwards":
                    parent.controller.BoostForwards(time);
                    break;
                case "backwards":
                    parent.controller.BoostBackwards(time);
                    break;
                case "rotateLeft":
                    parent.controller.Rotate(time, SpacecraftController.Direction.Left);
                    break;
                case "rotateRight":
                    parent.controller.Rotate(time, SpacecraftController.Direction.Right);
                    break;
            }
            parent.spacecraftManeuvers.Remove(this);
        }
    }
}
