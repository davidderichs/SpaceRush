using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private GameObject indicator1;
    private GameObject indicator2;
    public int id;
    public bool isFull;
    private GameManager game;

    // Use this for initialization
    void Start()
    {
        indicator1 = transform.Find("indicator1").gameObject;
        indicator2 = transform.Find("indicator2").gameObject;
        isFull = false;
        game = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
            if (other.transform.gameObject.name == "Spacecraft1" && other.transform.gameObject.tag == "spacecraft")
            {
                Debug.Log("Id" + id);
                indicator1.SetActive(true);
                indicator1.GetComponent<Renderer>().material.SetColor("Color_DDEDA7A6", game.player_1.playerColor);
                game.player_1.addCheckpoint(id);
                isFull = true;
            }

            if (other.transform.gameObject.name == "Spacecraft2" && other.transform.gameObject.tag == "spacecraft")
            {
                Debug.Log("id:" + id);
                indicator2.SetActive(true);
                indicator2.GetComponent<Renderer>().material.SetColor("Color_DDEDA7A6", game.player_2.playerColor);
                game.player_2.addCheckpoint(id);
                isFull = true;
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
