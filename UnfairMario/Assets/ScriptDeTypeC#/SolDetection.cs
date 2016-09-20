using UnityEngine;
using System.Collections;

public class SolDetection : MonoBehaviour {

    private MarioMoves player;
	void Start () {
        player = GetComponentInParent<MarioMoves>();
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
            player.Sol = true;
    }

    void OnTriggerStay2D(Collider2D coll)
    {
            player.Sol = true;
    }
    
    void OnTriggerExit2D(Collider2D coll)
    {
            player.Sol = false;
    }
}
