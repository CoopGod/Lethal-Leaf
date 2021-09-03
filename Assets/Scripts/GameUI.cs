using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    public GameObject gameLoseMenu;
    public GameObject gameWinMenu;
    
    private string currentLevel;

    void Start()
    {
        FindObjectOfType<Player>().OnDeath += OnGameOver;
        currentLevel = SceneManager.GetActiveScene().name;
    } // Called once on the starting frame

    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene(currentLevel);
        }
    } // Check for retry button pressed

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
        // Will be activated by the MainMenu button
        // Not implemented yet
    } // Return to the MainMenu when called

    public void SettingsMenu()
    {
        // Will be activated upon button press
        // Not implemented yet
    } // Open a settings screen when called
} // End of Class