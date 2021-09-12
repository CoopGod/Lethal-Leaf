using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    int playerHealth;
    public AudioSource hurt;

    // Hearts
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    Image heart3Img;
    Image heart2Img;
    Image heart1Img;

    // to see if sound has played
    bool sound1Played = false;
    bool sound2Played = false;
    bool sound3Played = false;

    // Start is called before the first frame update
    void Start()
    {
        // find images
        heart1Img = heart1.GetComponent<Image>();
        heart2Img = heart2.GetComponent<Image>();
        heart3Img = heart3.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth <= 2)
        {
            heart3Img.color = new Color32(116, 116, 116, 255);
            if (!sound1Played)
            {
                hurt.Play();
                sound1Played = true;
            }
            
        }

        if (playerHealth <= 1)
        {
            heart2Img.color = new Color32(116, 116, 116, 255);
            if (!sound2Played)
            {
                hurt.Play();
                sound2Played = true;
            }
        }

        if (playerHealth <= 0)
        {
            heart1Img.color = new Color32(116, 116, 116, 255);
            if (!sound3Played)
            {
                hurt.Play();
                sound3Played = true;
            }
        }
    }
}
