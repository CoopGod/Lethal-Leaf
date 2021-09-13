using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    public GameObject gameLoseMenu;
    public GameObject gameWinMenu;
    public Button retryButtonObj;
    public Button mainMenuButtonObj;
    public Button nextLevelButtonObj;
    
    private int currentLevel;

    void Start()
    {
        FindObjectOfType<Player>().OnDeath += OnGameOver;
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        retryButtonObj.onClick.AddListener(RetryButton);
        mainMenuButtonObj.onClick.AddListener(MainMenu);
        nextLevelButtonObj.onClick.AddListener(NextLevel);
    } // Called once on the starting frame

    void OnGameOver()
    {
        ShowGameOverMenu(gameLoseMenu);
    } // Called by the Action within LivingEntity when the player dies

    void OnGameWin()
    {
        ShowGameOverMenu(gameWinMenu);
    } // Called when the player wins the game

    public void ShowGameOverMenu(GameObject gameOverMenu)
    {
        // Show game over menu based on the gameUI provided on function call
        gameOverMenu.SetActive(true);
    } // End of ShowGameOverMenu

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    } // Return to the MainMenu when called

    public void RetryButton()
    {
        SceneManager.LoadScene(currentLevel);
    } // When Retry Button is clicked

    public void NextLevel()
    {
        SceneManager.LoadScene(currentLevel + 1);
    } // Go to the next level

} // End of Class