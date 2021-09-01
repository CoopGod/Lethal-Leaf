using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class motherCowLogic : MonoBehaviour
{
    public float reactionTime = 0.75f;
    float attackTime;
    bool playerInRange = false;

    void Update()
    {
        if (Time.time >= attackTime) // if it is time for the cow to attack...
        {
            // player animation or whatever...

            // if player is still in range, end them
            if (playerInRange == true)
            {
                Debug.Log("Player is dead");
            }
        }
    } // Update is called once per frame

    void OnTriggerEnter2D(Collider2D col)
    {
        float currentTime = Time.time;
        attackTime = Time.time + reactionTime;
        playerInRange = true;

    } // set attack time if player is in range

    void OnTriggerExit2D(Collider2D col)
    {
        playerInRange = false;
    } // let update know if the player has escaped the cow
}