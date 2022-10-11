using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OnClickEvents : MonoBehaviour
{
    public TextMeshProUGUI soundText;

    private void Start(){
        if(GameManager.mute)
            soundText.text = "/";
        else
            soundText.text = "";
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Exited");
    }
    public void ToggleMute()
    {
        if(GameManager.mute)
        {
            GameManager.mute = false;
            soundText.text = "";
        }
        else if{
            GameManager.mute = true;
            soundText.text = "/";
        }
    }
}
