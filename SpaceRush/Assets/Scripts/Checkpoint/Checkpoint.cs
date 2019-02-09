using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Light point;
    public int id;
    public bool isFull;
    private GameManager game;

    // Use this for initialization
    void Start()
    {
        isFull = false;
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
                isFull = true;
            }
            else
            {
                point.color = Color.green;
                game.checkpointTriggered(id, game.player_1);
                isFull = true;
            }

        }

        if (other.transform.gameObject.name == "Spacecraft2")
        {
            if (point.color == Color.red)
            {
                point.color = game.player_1.playerColor;
                game.checkpointTriggered(id, game.player_2);
                isFull = true;
            }
            else
            {
                point.color = Color.green;
                game.checkpointTriggered(id, game.player_2);
                isFull = true;
            }
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (isFull != true)
            isFull = true;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        isFull = false;
    }
}
