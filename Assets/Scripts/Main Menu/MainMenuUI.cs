using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public Button startButton;
    public int levelToLoad;

    void Start()
    {
        startButton.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void TaskOnClick()
    {
        LoadScene();
    }

    // Load scene... obviously
    void LoadScene() 
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
