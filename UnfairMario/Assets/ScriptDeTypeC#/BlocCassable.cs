using UnityEngine;
using System.Collections;

public class BlocCassable : MonoBehaviour
{
    GameObject parent;

    void Start()
    {
        parent = transform.parent.gameObject;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        Destroy(parent, 0.1f);
    }
}