using UnityEngine;
using System.Collections;

public class MouvementDeCamera : MonoBehaviour {
    private Vector2 velocity;

    public float smoothtTimeX;
    public GameObject player;

    void Start()
    {
        player = GameObject.Find("Mario");
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
    }
}