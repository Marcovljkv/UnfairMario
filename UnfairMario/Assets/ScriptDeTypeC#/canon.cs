using UnityEngine;
using System.Collections;

public class canon : MonoBehaviour
{

    public GameObject Missile;
    int timer = 0;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timer == 80)
        {
            GameObject unClone = Instantiate(Missile, new Vector3(4f, -2.1f, 0), Quaternion.identity) as GameObject;
            unClone.transform.parent = transform;

            timer = 0;
        }
        timer++;

    }
}