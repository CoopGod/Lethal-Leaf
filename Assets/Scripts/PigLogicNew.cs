using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(SpriteRenderer))]
[RequireComponent (typeof(AudioSource))]
public class PigLogicNew : MonoBehaviour
{
    // player location variables
    GameObject player;
    Transform playerTrans;
    SpriteRenderer spriteRenderer;
    AudioSource hurtSound;

    public float speed = 10f;
    public float damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>().gameObject;
        playerTrans = player.GetComponent<Transform>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        hurtSound = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTrans != null)
        {
            // Flip pig to face player
            if (playerTrans.position.x > transform.position.x)
            {
                spriteRenderer.flipX = false;
            }
            else
            {
                spriteRenderer.flipX = true;
            }
        }

        // Move pig
        Vector2 direction = new Vector2(playerTrans.position.x - transform.position.x, playerTrans.position.y - transform.position.y).normalized;
        Vector3 velocity = new Vector3(direction.x * speed, direction.y * speed, 0);
        transform.position += velocity * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
        {
            player.GetComponent<IDamageable>().TakeDamage(damage);
            hurtSound.Play();
        }
    }
}
