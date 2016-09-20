using UnityEngine;
using System.Collections;

public class Missiles : MonoBehaviour
{

    Rigidbody2D rb2d;
    GameObject player;

    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.Find("Mario");
    }

    void FixedUpdate()
    {
        rb2d.AddForce(Vector2.left * 10);

        if (Mathf.Abs(rb2d.velocity.x) > 5.5f)
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * 5.5f, rb2d.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "Mario")
        {
            player.SendMessage("MarioMeurt");
        }
    }
}