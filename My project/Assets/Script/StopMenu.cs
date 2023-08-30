using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StopMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public GameObject pauseMenuUI;
    public GameObject pauseButton;
    // Update is called once per frame
    void Update()
    {
    }
    public void PauseCheck(){
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        pauseButton.SetActive(false);
    }
    public void Continue(){
        Time.timeScale = 1f;
        pauseButton.SetActive(true);
        pauseMenuUI.SetActive(false);
    }
    public void GoMenu(){
        SceneManager.LoadScene("StartScreen");
        Time.timeScale = 1f;
        pauseButton.SetActive(true);
        pauseMenuUI.SetActive(false);
    }
    public void ExitGame(){
        Application.Quit();   
        Time.timeScale = 1f;
        pauseButton.SetActive(true);
        pauseMenuUI.SetActive(false);
    }
}
