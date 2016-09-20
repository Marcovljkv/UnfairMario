using UnityEngine;
using System.Collections;

public class GoombaMoves : MonoBehaviour
{
    float speed = 40f;
    bool right = false;
    float maxSpeed = 2f;
    private Rigidbody2D rb2d;
    GameObject player;


    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Mario");
    }

    void FixedUpdate()
    {
        if (right)
            rb2d.AddForce(Vector2.right * speed);
        else
            rb2d.AddForce(Vector2.left * speed);
        //Vitesse Max
        if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "Mario")
        {
           player.SendMessage("MarioMeurt");
        }
        else
        {
            right = !right;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
         
    }
}