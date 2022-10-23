using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHighscores : MonoBehaviour 
{
    public TMPro.TextMeshProUGUI[] name;
    public TMPro.TextMeshProUGUI[] score;

    HighScores myScores; //A reference to the HighScore script

    void Start() //Fetches the Data at the beginning
    {
        for (int i = 0; i < name.Length;i ++)
        {
            name[i].text = i + 1 + ". Fetching...";
        }
        myScores = GetComponent<HighScores>();
        StartCoroutine("RefreshHighscores");
    }
    public void SetScoresToMenu(PlayerScore[] highscoreList) //Assigns proper name and score for each text value
    {
        for (int i = 0; i < name.Length;i ++)
        {
            name[i].text = i + 1 + ". ";
            if (highscoreList.Length > i)
            {
                score[i].text = highscoreList[i].score.ToString();
                name[i].text = highscoreList[i].username;
            }
        }
    }
    IEnumerator RefreshHighscores() //Refreshes the scores every 60 seconds
    {
        while(true)
        {
            myScores.DownloadScores();
            yield return new WaitForSeconds(60);
        }
    }
}
