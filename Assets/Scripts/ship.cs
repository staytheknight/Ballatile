using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ship : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed;

    public Rigidbody2D rb;
    public GameObject hitEffect;
    public Sprite boostShip;
    public Sprite idleShip;

    Vector2 movement;
    
  
    // Start is called before the first frame update
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");


        // Rotates the sprite based on where the inputs are pointing
        if(movement != Vector2.zero) 
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, movement);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);


        }
        
    }

    // Fixed update for physics
    private void FixedUpdate()
    {
        // fixedDeltaTime is to assure that the movement speed is not affected by frame rate.
        // Such that the move speed will remain consistent 
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        if (movement.x != 0 || movement.y != 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = boostShip;
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = idleShip;
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {   
        // If the ship hits a wall or a ball, it dies
        if (collision.collider.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        else if (collision.collider.CompareTag("Ball")) 
        {
            Destroy(gameObject);
        }

        // Creates an animation effect, and destroys the ship
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.25f);


 
    }


}
