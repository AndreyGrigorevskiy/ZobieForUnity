using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public float waitTime = 10f;
    public GameObject zombee;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Spawn", waitTime);
    }

    // Update is called once per frame
    void Spawn()
    {
        Instantiate(zombee, transform.position, transform.rotation);
        if (waitTime > .2f)
            waitTime -= .2f;
        Invoke("Spawn", waitTime);
    }
}
