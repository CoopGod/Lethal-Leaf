using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SheepLogic : MonoBehaviour
{
    // playter location variables
    public GameObject player;
    Transform playerTrans;

    // Sheep Variables
    public SpriteRenderer spriteRenderer;
    public float speed;
    float xSpeed = 0;
    float ySpeed = 0;

    // Testing
    bool goTime = false;

    // Start is called before the first frame update
    void Start()
    {
        playerTrans = player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // Flip sheep to face player
        if (playerTrans.position.x > transform.position.x)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }
        
        if (Time.time >= 1)
        {
            goTime = true;
        }

        if (goTime)
        {
            
            AttackPlayer(playerTrans.position);
        }

        // Move sheep (be sure to reset x&y speeds to zero during transitions)
        transform.position = new Vector2(transform.position.x + (xSpeed * Time.deltaTime), transform.position.y + (ySpeed * Time.deltaTime));
    }

    // Sends sheep toward a players position in that moment
    void AttackPlayer(Vector3 playerPos)
    {
        // Get location of attack
        float distance = Vector3.Distance(playerPos, transform.position);
        float xDifference = playerPos.x - transform.position.x;
        float yDifference = playerPos.y - transform.position.y;

        // use speed to calculate how fast each side should mover by
        float xMultiplyer = distance / xDifference;
        float yMultiplyer = distance / yDifference;
        xSpeed = speed / xMultiplyer;
        ySpeed = speed / yMultiplyer;
    }
}
