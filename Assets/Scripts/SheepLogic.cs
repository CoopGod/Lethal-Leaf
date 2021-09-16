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
    public AudioSource hurtSound;
    public float speed;
    public float reactionTime;
    public Animator animator;
    float xSpeed = 0;
    float ySpeed = 0;
    bool goTime = true;
    Vector3 stopSpot;

    // fucking timing bullshit
    float stopTime;
    float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        playerTrans = player.GetComponent<Transform>();
        stopSpot = playerTrans.position;
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

        // If able to attack, do so
        if (goTime)
        {
            goTime = false;
            Debug.Log("TEST");
            Vector3 currentPos = playerTrans.position;
            AttackPlayer(currentPos);
            
        }

        // Check if sheep is within stop spot. if so, stop moving
        if (Vector3.Distance(transform.position, stopSpot) <= 2)
        {
            animator.SetBool("isConfused", true);
            xSpeed = 0;
            ySpeed = 0;
            if (Time.time >= stopTime + reactionTime)
            {
                goTime = true;
                animator.SetBool("isConfused", false);
            }
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

        // tell sheep where to stop
        stopSpot = playerPos;

        // fucking timing
        stopTime = (1/speed) * distance + Time.time;
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
        {
            hurtSound.Play();
        }
    }
}
