using UnityEngine;
using System.Collections;

public class BlocInvisible : MonoBehaviour
{
    GameObject parent;

    void Start()
    {
        transform.parent.gameObject.GetComponent<Renderer>().enabled = false;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        transform.parent.gameObject.GetComponent<Renderer>().enabled = true;
    }
}