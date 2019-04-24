using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scoring_System : MonoBehaviour {

    private float elapsedTime = 0;
    public int score = 0;
    public int lives = 3;
    public int consecutiveHits = 0;
    public GameObject timeUI;
    public GameObject scoreUI;
    public GameObject hitStreak;
    GameObject[] gameOverObjects;
    GameObject livesRemaining;

    // Use this for initialization
    void Start ()
    {
        // Save_System.manageData.LoadData();
        Time.timeScale = 1;
        gameOverObjects = GameObject.FindGameObjectsWithTag("ShowGameOver");
        HideGameOver();
    }
	
	// Update is called once per frame
	void Update ()
    {
        elapsedTime += Time.deltaTime;
        timeUI.gameObject.GetComponent<Text>().text = ("Time: " + (int)elapsedTime);
        scoreUI.gameObject.GetComponent<Text>().text = ("Score: " + score);
        hitStreak.gameObject.GetComponent<Text>().text = ("Hit Streak: " + consecutiveHits);
    }

    // Goes to game over screen and pauses game
    void RestartGame()
    {
        Time.timeScale = 0;
        ShowGameOver();
    } 

    // Show game over UI elements
    public void ShowGameOver()
    {
        foreach (GameObject g in gameOverObjects)
        {
            g.SetActive(true);
        }
    }

    // Hide game over UI elements
    public void HideGameOver()
    {
        foreach (GameObject g in gameOverObjects)
        {
            g.SetActive(false);
        }
    }


    public void LoseLives(string lifeNumber)
    {
        livesRemaining = GameObject.Find(lifeNumber);
        livesRemaining.SetActive(false);
        consecutiveHits = 0;
    }

    // Add to score and consecutive hits
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "LeftPaddle" || col.gameObject.tag == "RightPaddle")
        {
            score += 10;
            consecutiveHits += 1;
        }
    }

    // Lose lives when ball hits kill boundary and restart game when lives hits 0
    void OnTriggerEnter2D(Collider2D trig)
    {
        // CountScore();
        // Save_System.manageData.SaveData();
        if (trig.gameObject.tag == "KillBound")
        {
            lives -= 1;

            if (lives == 2)
            {
                LoseLives("FirstLife");
            }

            else if (lives == 1)
            {
                LoseLives("MiddleLife");
            }

            else if (lives < 1)
            {
                LoseLives("LastLife");
                Invoke("RestartGame", 1);
                lives = 3;
            }
        }
    }

    void CountScore()
    {
        // score = score + (int)(elapsedTime * 5);
        // Save_System.manageData.highScore = score;
        // Save_System.manageData.SaveData();
    }
}
