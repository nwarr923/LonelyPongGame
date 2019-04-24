using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle_Move : MonoBehaviour {

    public float paddleSpeed = 5;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        PaddleMove();
	}

    // Inputs and movement for paddles
    void PaddleMove()
    {
        //Controls
        if (gameObject.tag == "RightPaddle")
        {
            if ((Input.GetKey(KeyCode.DownArrow)) || (Input.GetAxis("RightJoyStickY") < 0))
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.down * paddleSpeed;
            }
            else if ((Input.GetKey(KeyCode.UpArrow)) || (Input.GetAxis("RightJoyStickY") > 0))
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * paddleSpeed;
            }
            else
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }


        }
        else if (gameObject.tag == "LeftPaddle")
        {
            if ((Input.GetKey(KeyCode.S)) || (Input.GetAxis("LeftJoyStickY") < 0))
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.down * paddleSpeed;
            }
            else if ((Input.GetKey(KeyCode.W)) || (Input.GetAxis("LeftJoyStickY") > 0))
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * paddleSpeed;
            }
            else
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }
        }
    }
}
