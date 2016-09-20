using UnityEngine;
using System.Collections;

public class GoombaMario : MonoBehaviour {

    GameObject parent;
    private GoombaMoves goomba;

	void Start () {
        parent = transform.parent.gameObject;
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            GameObject.Find("Mario").GetComponent<MarioMoves>().Jump();
            parent.GetComponent<Animator>().Play("GoombaDead");
            Destroy(parent.GetComponent<Collider2D>());
            Destroy(parent, 0.3f);
        }
    }
}
