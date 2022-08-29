using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform spawner;
    public GameObject ball;
  
    // Start is called before the first frame update
    void Start()
    {   
        // Spawns a new ball every 5 seconds
        InvokeRepeating("Spawn", 3, 5);
    }

    void Spawn()
    {   
        // Spawns at new ball at the spawner
        Instantiate(ball, spawner.position, spawner.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
