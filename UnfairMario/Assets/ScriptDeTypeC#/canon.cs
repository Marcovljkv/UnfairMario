using UnityEngine;
using System.Collections;

public class canon : MonoBehaviour
{

    public GameObject Missile;
    GameObject departMissile;
    int timer = 0;
    // Use this for initialization
    void Start()
    {
        departMissile = GameObject.Find("DepartCanon");
    }

    // Update is called once per frame
    void Update()
    {
        if (timer == 80)
        {
            GameObject unClone = Instantiate(Missile,departMissile.transform.position , Quaternion.identity) as GameObject;
            unClone.transform.parent = transform;
            unClone.transform.localScale = new Vector3(0.75f,0.75f);

            timer = 0;
        }
        timer++;

    }
}