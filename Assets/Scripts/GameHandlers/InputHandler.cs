using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    void Update()
    {
        if (GameplayHandler.GameplayStarted && Input.GetKeyDown(KeyCode.Escape))
        {
            if(!GameplayHandler.GameplayPaused)
                CanvasButtons.Pause(); 
            else
                CanvasButtons.Unpause();
            CanvasButtons.PlayButtonClickSound();
        }       
    }
}
