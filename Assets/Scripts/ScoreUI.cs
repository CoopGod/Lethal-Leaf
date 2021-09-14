using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    private int leafPileCount;

    [HideInInspector]
    public int leavesRaked = 0;

    public event System.Action allRaked; 

    List<LeafPile> leafPiles = new List<LeafPile>();

    void Start()
    {
        leafPiles.AddRange(FindObjectsOfType<LeafPile>());
        leafPileCount = leafPiles.Count;
        UpdateScore();
    } // Start is called before the first frame update

    public void UpdateScore()
    {
        leavesRaked++;
        scoreText.text = leavesRaked + "/" + leafPileCount;
        if(leafPileCount == leavesRaked)
        {
            if(allRaked != null) allRaked();
        } // Check if all the piles have been raked
    } // Update the score
} // End of Class ScoreUI