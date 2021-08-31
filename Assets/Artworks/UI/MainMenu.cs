using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{   

    public bool isTouchControlOn = false;
    public static MainMenu instance;

    private void Awake() {
        instance = this;    
    }
    public void PlayGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }
    public void QuitGame(){
        Application.Quit();
    }

    public void ToggleTouchControl(){
        if (isTouchControlOn == false){
            isTouchControlOn = true;
        }
        else{
            isTouchControlOn = false;
        }
    }
    public bool ReturnTouchControl(){
        return isTouchControlOn;
    }
}
