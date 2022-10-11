using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
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

    public Slider gameProgressSlider;
    public TextMeshProUGUI currentLevelIndexText;
    public TextMeshProUGUI nextLevelText;

    //Called at the beginning of the gameplay
    private void Awake()
    {
        currentLevelIndex = PlayerPrefs.GetInt("CurrentLevelIndex", 1);
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        TowerRotator.rotationSpeed = 150f;
        isGameStarted = gameOver = levelCompleted = false;
        numberOfPassedChunks = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Update the UI
        currentLevelIndexText.text = currentLevelIndex.ToString();
        nextLevelText.text = (currentLevelIndex + 1).ToString();
        
        //Updates the progress UI bar(slider)
        int progress = numberOfPassedChunks * 100/FindObjectOfType<HelixManger>().numberOfChunks;
        gameProgressSlider.value = progress;

        if (Input.GetMouseButtonDown(0) && !isGameStarted)
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;

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
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        if (levelCompleted)
        {
            levelCompletedPanel.SetActive(true);
            if (Input.GetButtonDown("Fire1"))
            {
                PlayerPrefs.GetInt("CurrentLevelIndex", currentLevelIndex + 1);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
