using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveScoreData : MonoBehaviour
{
    public TMPro.TextMeshProUGUI myName;

    // Update is called once per frame
    void Update()
    {
        //GameManager.scoreText.text = $"{PlayerPrefs.GetInt("Highscore")}";
    }

    public void SendScore()
    {
        if(GameManager.score > PlayerPrefs.GetInt("Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", GameManager.score);
            HighScores.UploadScore(myName.text, GameManager.score);
        }
    }
}
