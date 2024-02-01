using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    public GameObject gameLoseMenu;
    public AudioSource gameLoseSound;
    public GameObject gameWinMenu;
    public AudioSource gameWinSound;
    public Button retryButtonObj;
    public Button mainMenuButtonObj;
    public Button nextLevelButtonObj;
    public Button mainMenuButtonObj2;
    public Text levelHolder;
    public AudioSource levelMusic;


    private int currentLevel;
    bool gameOver = false;

    void Start()
    {
        FindObjectOfType<Player>().OnDeath += OnGameOver;
        FindObjectOfType<ScoreUI>().allRaked += OnGameWin;
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        retryButtonObj.onClick.AddListener(RetryButton);
        mainMenuButtonObj.onClick.AddListener(MainMenu);
        mainMenuButtonObj2.onClick.AddListener(MainMenu);
        nextLevelButtonObj.onClick.AddListener(NextLevel);
        levelHolder.text = currentLevel.ToString();
    } // Called once on the starting frame

    void OnGameOver()
    {
        if (!gameOver)
        {
            ShowGameOverMenu(gameLoseMenu);
            gameOver = true;
            gameLoseSound.Play();
            levelMusic.Stop();
            Time.timeScale = 0;
        }
    } // Called by the Action within LivingEntity when the player dies

    void OnGameWin()
    {
        if (!gameOver)
        {
            ShowGameOverMenu(gameWinMenu);
            gameOver = true;
            levelMusic.volume = 0.1f;
            gameWinSound.Play();
            Time.timeScale = 0;
        }
    } // Called when the player wins the game

    public void ShowGameOverMenu(GameObject gameOverMenu)
    {
        // Show game over menu based on the gameUI provided on function call
        gameOverMenu.SetActive(true);
    } // End of ShowGameOverMenu

    public void MainMenu()
    {
        StartCoroutine(LoadScene(0));
    } // Return to the MainMenu when called

    public void RetryButton()
    {
        StartCoroutine(LoadScene(currentLevel));
    } // When Retry Button is clicked

    public void NextLevel()
    {
        StartCoroutine(LoadScene(currentLevel + 1));
    } // Go to the next level

    // Load scene... obviously
    IEnumerator LoadScene(int scene) 
    {
        Time.timeScale = 1;
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(scene);
    }

} // End of Class