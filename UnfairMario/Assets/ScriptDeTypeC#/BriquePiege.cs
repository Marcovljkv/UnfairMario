using UnityEngine;
using System.Collections;

public class BriquePiege : MonoBehaviour
{

    GameObject player;

    void Start()
    {
        player = GameObject.Find("Mario");
        trapVisible();
    }


    void trapVisible()
    {
        gameObject.GetComponent<Renderer>().enabled = !gameObject.GetComponent<Renderer>().enabled;
    }


    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.name == "Mario")
        {
            trapVisible();
            player.SendMessage("MarioMeurt");
        }
    }
}
