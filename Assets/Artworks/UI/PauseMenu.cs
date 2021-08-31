using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
   public static bool GameIsPaused = false;
   public static PauseMenu instance;
   public GameObject winScreenUI;
   public GameObject pauseMenuUI;
   public GameObject dieScreenUI;

    void Awake() {
        instance = this;    
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (GameIsPaused){
                Resume();
            }
            else {
                Pause();
            }
        }
    }

    public void Resume(){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause(){
        pauseMenuUI.SetActive(true);
        Time.timeScale =0f;
        AudioManager.instance.Stop("enemy_grunt");
        GameIsPaused = true;
    }
    public void QuitTOStartScreen(){
        Time.timeScale =1f;
        SceneManager.LoadScene(0);
    }
    public void DieScreen(){
        dieScreenUI.SetActive(true);
        AudioManager.instance.Stop("enemy_grunt");
        Time.timeScale = 0f;
    }
    public void GotoWinScreen(){
        winScreenUI.SetActive(true);
        AudioManager.instance.Stop("enemy_grunt");
    }
    public void RestartGame(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
}
