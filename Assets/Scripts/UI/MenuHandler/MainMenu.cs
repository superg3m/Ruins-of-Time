using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Canvas exitDialog;
    [SerializeField] private Text VolumeText;
    [SerializeField] private Slider VolumeSlider;

    private void Start()
    {
        exitDialog.gameObject.SetActive(false);
    }
    public void playGame()
    {
        SceneManager.LoadScene("Game");
    }
    
    public void goToOptionsMenu()
    {
        SceneManager.LoadScene("OptionMenu");
    }

    public void SetVolume(int volume)
    {

    }


    public void goBack()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void exitGame()
    {
        exitDialog.gameObject.SetActive(true);
    }

    public void exitGame_yes()
    {
        Application.Quit();
    }
    public void exitGame_no()
    {
        exitDialog.gameObject.SetActive(false);
    }



}
