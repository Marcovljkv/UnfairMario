using UnityEngine;
using System.Collections;

public class NuagePiege : MonoBehaviour
{
    GameObject player;

    void Start()
    {
        player = GameObject.Find("Mario");
        changerTrapNuage();
    }


    void changerTrapNuage()
    {
        Renderer[] traps = gameObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer trap in traps)
        {
            if (trap.name != "NuagePiege")
                trap.enabled = !trap.enabled;
        }
    }
    

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "Mario")
        {
            changerTrapNuage();
            player.SendMessage("MarioMeurt");
        }
    }
}