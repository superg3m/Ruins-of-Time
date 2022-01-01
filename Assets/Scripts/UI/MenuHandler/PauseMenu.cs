using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Canvas Pause_UI;
    public bool gameIsPaused;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("WORKING");
            if(gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        gameIsPaused = false;
        Pause_UI.GetComponent<Canvas>().enabled = false;
        Time.timeScale = 1.0f;
    }

    public void Pause()
    {
        gameIsPaused = true;
        Pause_UI.GetComponent<Canvas>().enabled = true;
        Time.timeScale = 0f;
    }
}
