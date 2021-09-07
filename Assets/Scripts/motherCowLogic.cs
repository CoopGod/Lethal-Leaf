using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherCowLogic : LivingEntity
{
    public float reactionTime = 0.75f;
    public float damage = 1;
    public float attackRange = 10;
    public float attackTime = 1;
    public float collisionRadius;

    bool playerInRange = false; 

    IDamageable player;
    Transform target;
    Collider2D circleCollider;
    SpriteRenderer cowSprite;

    protected override void Start()
    {
        base.Start();
        player = FindObjectOfType<Player>().gameObject.GetComponent<IDamageable>();
        target = FindObjectOfType<Player>().transform;
        cowSprite = GetComponent<SpriteRenderer>();
    } // Start

    void Update()
    {
        if (Time.time >= attackTime) // if it is time for the cow to attack...
        {
            // player animation or whatever...

            // if player is still in range, end them
            if (playerInRange == true)
            {
                player.TakeDamage(damage);
            }
        }
    } // Update is called once per frame

    void OnTriggerEnter2D(Collider2D col)
    {
        attackTime = Time.time + reactionTime;
        playerInRange = true;
        cowSprite.color = Color.red;
    } // set attack time if player is in range

    void OnTriggerExit2D(Collider2D col)
    {
        playerInRange = false;
        cowSprite.color = Color.white;
    } // let update know if the player has escaped the cow

    // IEnumerator Attack()
    // {

    // } // Attack the player after changing color to show anger.

    // IEnumerator CalmDown()
    // {

    // } // Revert the color back down so he calms down.

} // End of class MotherCowLogic