using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDialog : MonoBehaviour
{
    [SerializeField] private Canvas exitDialog;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            exitDialog.GetComponent<Canvas>().enabled = true;
        }
    }
    public void exitGame()
    {
        exitDialog.GetComponent<Canvas>().enabled = true;
    }
    public void exitGame_yes()
    {
        Application.Quit();
    }

    public void exitGame_no()
    {
        exitDialog.GetComponent<Canvas>().enabled = false;
    }
}
