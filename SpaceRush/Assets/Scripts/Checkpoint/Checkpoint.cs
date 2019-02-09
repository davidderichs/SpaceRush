using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private GameObject indicator1;
    private GameObject indicator2;
    public int id;
    private GameManager game;

    // Use this for initialization
    void Start()
    {
        indicator1 = transform.Find("indicator1").gameObject;
        indicator2 = transform.Find("indicator2").gameObject;
        game = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.gameObject.name == "Spacecraft1")
        {
            indicator1.GetComponent<Renderer>().material.SetColor("Color_DDEDA7A6", game.player_1.playerColor);
            indicator1.SetActive(true);
            game.checkpointTriggered(id, game.player_1);
        }

        if (other.transform.gameObject.name == "Spacecraft2")
        {
            indicator2.GetComponent<Renderer>().material.SetColor("Color_DDEDA7A6", game.player_2.playerColor);
            indicator2.SetActive(true);
            game.checkpointTriggered(id, game.player_2);
        }
    }
}
