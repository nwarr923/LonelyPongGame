using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{

    GameObject[] pausedObjects;

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;
        pausedObjects = GameObject.FindGameObjectsWithTag("ShowPause");
        HidePaused();
    }

    // Update is called once per frame
    void Update()
    {
        // Pause the game
        if (Input.GetKeyDown(KeyCode.Escape) || (Input.GetKeyDown(KeyCode.P)))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                ShowPaused();
            }
            else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                HidePaused();
            }
        }
    }

    // Load scene based on passed in name
    public void SceneLoad(string SceneToLoad)
    {
        SceneManager.LoadScene(SceneToLoad);
    }

    // Exit the game
    public void ExitGame()
    {
        Application.Quit();
    }

    // Pause and unpause game, show and hide pause menu
    public void PauseControl()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            ShowPaused();
        }

        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            HidePaused();
        }
    }

    // Show paused UI elements
    public void ShowPaused()
    {
        foreach (GameObject g in pausedObjects)
        {
            g.SetActive(true);
        }
    }

    // Hide paused UI elements
    public void HidePaused()
    {
        foreach (GameObject g in pausedObjects)
        {
            g.SetActive(false);
        }
    }
}
