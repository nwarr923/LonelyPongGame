// This is used for the design aesthetic of the main menu and the moving squares
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSquare : MonoBehaviour {

    private Rigidbody2D rb2d;
    public float speed = 3f;

    void GoBall()
    {
        rb2d.constraints = RigidbodyConstraints2D.None;
        rb2d.velocity = Random.insideUnitCircle.normalized * speed;
    }

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        GoBall();
    }

    void Update()
    {
        if ((rb2d.velocity.x < 1) && (rb2d.velocity.x > -1))
        {
            GoBall();
        }
    }
}


