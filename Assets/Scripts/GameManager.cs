using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool gameOver;
    public static bool levelCompleted;

    public GameObject gameOverPanel;
    public GameObject levelCompletedPanel;

    public static int currentLevelIndex;

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
        gameOver = levelCompleted = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Update the UI
        currentLevelIndexText.text = currentLevelIndex.ToString();
        nextLevelText.text = (currentLevelIndex + 1).ToString();
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
