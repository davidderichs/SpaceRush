using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementsTester : MonoBehaviour
{

    public float timeBetweenMovements;
    public string firstMovement;
    public string secondMovement;
    public string thirdMovement;
    public string fourthMovement;
    public string fifthMovement;
    private Spacecraft spacecraft;
    private float timer;

    void Start()
    {
        spacecraft = GetComponent<Spacecraft>();
        timer = 0f;
        addMovement(firstMovement);
        addMovement(secondMovement);
        addMovement(thirdMovement);
        addMovement(fourthMovement);
        addMovement(fifthMovement);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeBetweenMovements)
        {
            spacecraft.StartNextMovement();
            timer = 0;
        }
    }

    private void addMovement(string description)
    {
        string[] data = description.Split(',');
        if (data.Length == 4)
        {
            string type = data[0].Trim();
            SpacecraftMovement.Direction direction;
            switch (data[1].Trim())
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
                default: return;
            }
            float forceOrSpeed = float.Parse(data[2]);
            float duration = float.Parse(data[3]);
            switch (type)
            {
                case "boost":
                    spacecraft.AddMovement(new SpacecraftBoost(direction, forceOrSpeed, duration));
                    break;
                case "rotate":
                    spacecraft.AddMovement(new SpacecraftRotation(direction, forceOrSpeed, duration));
                    break;
            }
        }
    }
}
