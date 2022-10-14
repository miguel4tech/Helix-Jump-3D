using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    #region VARIABLES
    public static bool isGameStarted;
    public static bool gameOver;
    public static bool levelCompleted;
    public static bool mute;

    public GameObject gamePlayPanel;
    public GameObject gameOverPanel;
    public GameObject startMenuPanel;
    public GameObject levelCompletedPanel;


    public static int currentLevelIndex;
    public static int numberOfPassedChunks;
    public static int score;

    public Slider gameProgressSlider;
    public TextMeshProUGUI currentLevelIndexText;
    public TextMeshProUGUI nextLevelText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    #endregion
    //Called at the beginning of the gameplay
    private void Awake()
    {
        currentLevelIndex = PlayerPrefs.GetInt("CurrentLevelIndex", 1);
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        TowerRotator.rotationSpeed = 10f;
        isGameStarted = gameOver = levelCompleted = false;
        numberOfPassedChunks = 0;

        highScoreText.text = "" + PlayerPrefs.GetInt("Highscore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        //Update the UI
        currentLevelIndexText.text = currentLevelIndex.ToString();
        nextLevelText.text = (currentLevelIndex+1).ToString();
        scoreText.text = score.ToString();
        
        //Updates the progress UI bar(slider)
        int progress = numberOfPassedChunks * 100/FindObjectOfType<HelixManger>().numberOfChunks;
        gameProgressSlider.value = progress;


        //Start A Level

        //Commented out for PC
        //if (Input.GetMouseButtonDown(0) && !isGameStarted)

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && !isGameStarted)
        {
            //Commented out for PC
            //if (EventSystem.current.IsPointerOverGameObject())
            //   return;
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                {return;}

            isGameStarted = true;
            gamePlayPanel.SetActive(true);
            startMenuPanel.SetActive(false);
        }

        //Checks if game is over
        if(gameOver)
        {
            //Time.timeScale = 0; //Freezes gameplay
            gameOverPanel.SetActive(true);
            TowerRotator.rotationSpeed = 0;
            if (Input.GetButtonDown("Fire1"))
            {
                //Check for highscore
                if(score > PlayerPrefs.GetInt("Highscore", 0))
                {
                    PlayerPrefs.SetInt("Highscore", score);
                }

                //Resets the value to zero 0
                score = 0;
                
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        if (levelCompleted)
        {
            levelCompletedPanel.SetActive(true);
            if (Input.GetButtonDown("Fire1"))
            {
                PlayerPrefs.SetInt("CurrentLevelIndex", currentLevelIndex + 1);
                SceneManager.LoadScene("Level");
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
