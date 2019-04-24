using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball_Move : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float speed = 5f;

    // Gives ball velocity and random direction
    void GoBall()
    {
        rb2d.constraints = RigidbodyConstraints2D.None;
        gameObject.GetComponent<TrailRenderer>().enabled = true;

        float rand = Random.Range(0, 2);
        if (rand < 1)
        {
            rb2d.velocity = Vector2.right * speed;
        }
        else
        {
            rb2d.velocity = Vector2.left * speed;
        }
    }

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Invoke("GoBall", 2f);
    }

    // Sets ball back to starting position and sets speed back to default value
    void ResetBall()
    {
        rb2d.velocity = new Vector2(0, 0);
        gameObject.GetComponent<TrailRenderer>().enabled = false;
        transform.position = Vector2.zero;
        speed = 5f;
        Invoke("GoBall", 1f);
    }

    // Calculate the direction the ball will bounce when hitting paddle
    float HitFactor(Vector2 ballPos, Vector2 paddlePos, float paddleHeight)
    {
        float bounceDir = 1;
        
        bounceDir = ((ballPos.y - paddlePos.y) / paddleHeight) + (Random.Range(-2,3) / 15);
        Debug.Log("Direction is " + bounceDir);
        
        return bounceDir;
    }

    // Kills the ball, takes away one life, and resets the ball position
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "KillBound")
        {
            col.gameObject.GetComponent<AudioSource>().Play();
            gameObject.GetComponent<Animator>().SetTrigger("KillBoundCollision");
            rb2d.velocity = new Vector2(0, 0);
            Invoke("ResetBall", 1f);
        }
    }

    // Angle the ball on every collision.
    void OnCollisionEnter2D(Collision2D col)
    {
        // Hit the left paddle
        if (col.gameObject.name == "LeftPaddle")
        {
            GetComponent<AudioSource>().Play();

            // Calculate hit Factor
            float y = HitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(1, y).normalized;

            if (speed < 15)
            {
                speed += .333f;
            }

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

        // Hit the right paddle
        if (col.gameObject.name == "RightPaddle")
        {
            GetComponent<AudioSource>().Play();

            // Calculate hit Factor
            float y = HitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(-1, y).normalized;

            if (speed < 15)
            {
                speed += .333f;
            }
            
            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
    }
}
