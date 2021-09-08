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

    private float angryPercent = 0;
    private float calmPercent = 1;

    bool playerInRange = false; 

    IDamageable player;
    Transform target;
    Collider2D circleCollider;
    SpriteRenderer cowSprite;
    Color originalColor;
    Color angryColor;

    Animator animator;

    protected override void Start()
    {
        base.Start();
        player = FindObjectOfType<Player>().gameObject.GetComponent<IDamageable>();
        target = FindObjectOfType<Player>().transform;
        cowSprite = GetComponent<SpriteRenderer>();
        originalColor = cowSprite.color;
        angryColor = Color.red;
        animator = GetComponent<Animator>();
    } // Start

    void Update()
    {
        
    } // Update is called once per frame

    void OnTriggerEnter2D(Collider2D col)
    {
        // attackTime = Time.time + reactionTime; // don't need anymore -- matt lemme know what you're planning regarding the old way of attacking
        playerInRange = true;
        StartCoroutine( AngerManagement() );
    } // set attack time if player is in range

    void OnTriggerExit2D(Collider2D col)
    {
        playerInRange = false;
        StartCoroutine( AngerManagement() );
    } // let update know if the player has escaped the cow

    IEnumerator AngerManagement()
    {   
        while(angryPercent <= 1 && playerInRange)
        {
            cowSprite.color = Color.Lerp(originalColor, angryColor, angryPercent);
            angryPercent += Time.deltaTime * reactionTime;
            yield return null;
        } // Get angry when da human is intruding on his private time

        if(angryPercent >= 1 && playerInRange)
        {
            player.TakeDamage(damage);
            animator.SetBool("isAttacking", true);
            yield return new WaitForSeconds(0.87f); // it works trust me
            animator.SetBool("isAttacking", false);
        } // Attack player and play animation

        while(angryPercent >= 0 && !playerInRange)
        {
            cowSprite.color = Color.Lerp(originalColor, angryColor, angryPercent);
            angryPercent -= Time.deltaTime * reactionTime;
            yield return null;
        } // Calm down while the player is not near

        yield break;
    } // Attack the player after changing color to show anger.

} // End of class MotherCowLogic