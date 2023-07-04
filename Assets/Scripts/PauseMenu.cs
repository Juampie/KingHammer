using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;
using SceneChangerNS;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pause;
    [SerializeField] private GameObject pauseMenu;
    
    public void PauseClick()
    {
        pause.SetActive(false);
        pauseMenu.SetActive(true);
        Time.timeScale = 0; 
    }

    public void ContinueClick()
    {
        pause.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void RestartClick()
    {
        pause.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneChanger.SceneNow);
    }
    public void MainMenuClick()
    {
        pause.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

}
