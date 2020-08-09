using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    public int Maxspeed;
    public int Maxspeedneg;
    public int jumpforce;
    bool canJump;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("left"))
        {

            gameObject.GetComponent<Rigidbody2D>().AddForce(new UnityEngine.Vector2(-3000f * Time.deltaTime, 0));

            gameObject.GetComponent<Animator>().SetBool("moving", true);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }

       



        if (Input.GetKey("right"))
        {

            gameObject.GetComponent<Rigidbody2D>().AddForce(new UnityEngine.Vector2(3000f * Time.deltaTime, 0));
            gameObject.GetComponent<Animator>().SetBool("moving", true);
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }

        if (!Input.GetKey("left") && !Input.GetKey("right"))
        {

            gameObject.GetComponent<Animator>().SetBool("moving", false);
        }


        if (Input.GetKey("up") && canJump)
        {

            canJump = false;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new UnityEngine.Vector2(0, jumpforce));
        }



        gameObject.GetComponent<Rigidbody2D>().velocity = new UnityEngine.Vector2( Math.Min(gameObject.GetComponent<Rigidbody2D>().velocity.x, Maxspeed), gameObject.GetComponent<Rigidbody2D>().velocity.y);
        gameObject.GetComponent<Rigidbody2D>().velocity = new UnityEngine.Vector2(Math.Max(gameObject.GetComponent<Rigidbody2D>().velocity.x, Maxspeedneg), gameObject.GetComponent<Rigidbody2D>().velocity.y);





    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.transform.tag == "ground")

            canJump = true;

    }
}
