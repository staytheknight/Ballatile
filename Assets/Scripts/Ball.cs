using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public GameObject ball2;
    public GameObject hitEffect;

    public float forceMax = 200f;
    public float forceMin = -200f;

    // Ball chooses a "random" direction, to start in
    void GoBall()
    {
        float randX = Random.Range(forceMin, forceMax);
        float randY = Random.Range(forceMin, forceMax);

        rb2d.AddForce(new Vector2(randX, randY));
    }

    // Start is called before the first frame update
    void Start()
    {   
        // Invokes the GoBall function, and chooses a random direction for the ball to go in
        rb2d = GetComponent<Rigidbody2D>();
        // Invokes GoBall to start after x seconds
        Invoke("GoBall", 0);
    }

    
    void makeBall()
    {
        // creates new balls
        GameObject ball = Instantiate(ball2, rb2d.position, transform.rotation);
    }

    void particleEffect ()
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.25f);
    }
       

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Wall"))
        {
                       
            // Changes velocity and direction of balls
            Vector2 vel;
            vel.x = rb2d.velocity.x;
            vel.y = rb2d.velocity.y;
            rb2d.velocity = -vel;

                        
            // destroys balls that hit the wall
            Destroy(gameObject);
                   

            // creates new balls
            makeBall();
            makeBall();

            // Creates particle effect on ball destruction
            // WATCH THIS IT MAY BREAK THE PHYSICS
            // KNOWN ISSUES: does not apply to smallest balls
            particleEffect();




        }
    }

}
