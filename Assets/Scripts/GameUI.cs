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
    
    private string currentLevel;

    void Start()
    {
        FindObjectOfType<Player>().OnDeath += OnGameOver;
        currentLevel = SceneManager.GetActiveScene().name;
        retryButtonObj.onClick.AddListener(RetryButton);
        mainMenuButtonObj.onClick.AddListener(MainMenu);
    } // Called once on the starting frame

    void OnGameOver()
    {
        ShowGameOverMenu(gameLoseMenu);
    } // Called by the Action within LivingEntity when the player dies

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
    }

} // End of Class