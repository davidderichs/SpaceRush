using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Light point;
    public int id;
    private GameManager game;

    // Use this for initialization
    void Start()
    {
        point = GetComponent<Light>();
        game = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.gameObject.name == "Spacecraft")
        {
            if (point.color == Color.red)
            {
                point.color = game.player_1.playerColor;
                game.checkpointTriggered(id, game.player_1);
            }
            else
            {
                point.color = Color.green;
                game.checkpointTriggered(id, game.player_1);

            }

        }

        if (other.transform.gameObject.name == "Spacecraft2")
        {
           if (point.color == Color.red)
            {
                point.color = game.player_1.playerColor;
                game.checkpointTriggered(id, game.player_2);
            }
            else
            {
                point.color = Color.green;
                game.checkpointTriggered(id, game.player_2);

            }
        }
    }
}
