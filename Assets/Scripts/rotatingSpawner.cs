using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatingSpawner : MonoBehaviour
{
    public Vector3 startRotation;

    public GameObject anchor;
    public GameObject ball;

    public Transform spawner;

    public Collider2D ballCollider;

    public float velocity = 30f;
    public bool isInvert;
    public int spawnTimer = 5;
    public int spawnRepeat = 5;

    // Start is called before the first frame update
    void Start()
    {
        transform.eulerAngles = startRotation;

        // Spawns a new ball every 5 seconds
        InvokeRepeating("Spawn", spawnTimer, spawnRepeat);
        

    }

    // Rotates the spawner around the center of the arena on the outside of the arena
    void Rotate()
    {
        if (!isInvert)
        {
            transform.RotateAround(anchor.transform.position, Vector3.forward, Time.deltaTime * velocity);
        }
        else
        {
            transform.RotateAround(anchor.transform.position, Vector3.forward, Time.deltaTime * -velocity);
        }
    }


    void Spawn()
    {   
        // Spawns new balls
        GameObject spawnedBall = Instantiate(ball, spawner.position, spawner.rotation);
        Rigidbody2D rb = spawnedBall.GetComponent<Rigidbody2D>();

        // Stops ball collision for 1 second
        StopCollision();

        // Ejects the ball
        rb.AddForce(spawner.up, ForceMode2D.Impulse);
            
    }

    // Supposed to stop the ball collision from turning on for a few seconds during spawn
    // so that it does not just explode
    // I DON'T THINK IT WORKS
    IEnumerator StopCollision()
    {   
        ballCollider.enabled = false;
        // wait for seconds needs to be set as a float 1.0f to work !!!!
        yield return new WaitForSeconds(1);
        ballCollider.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();

    }
}
