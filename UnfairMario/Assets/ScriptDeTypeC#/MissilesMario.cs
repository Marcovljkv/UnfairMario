using UnityEngine;
using System.Collections;

public class MissilesMario : MonoBehaviour
{

    GameObject parent;

    void Start()
    {
        parent = transform.parent.gameObject;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player" && gameObject.name == "DetectionMort")
        {
            Debug.Log("Missile Meurt");

            GameObject.Find("Mario").GetComponent<MarioMoves>().Jump();
            // parent.GetComponent<Animator>().Play("GoombaDead");
            Destroy(parent.GetComponent<Collider2D>());
            Destroy(parent, 0.3f);
        }
    }
}