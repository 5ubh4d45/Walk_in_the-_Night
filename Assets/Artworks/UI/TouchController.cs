using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    public GameObject controlButtons;
    //public MainMenu isTouchControlOn; 
    
    void Update()
    {
        if(MainMenu.instance.ReturnTouchControl() == true){
            controlButtons.SetActive(true);
        }
        else{
            controlButtons.SetActive(false);
        }
    }
}
