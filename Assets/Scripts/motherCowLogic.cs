using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherCowLogic : MonoBehaviour
{
    public float reactionTime = 0.75f;
    public float damage = 1;
    public float attackRange = 10;
    public float attackTime = 1;

    private float angryPercent = 0;

    bool playerInRange = false; 
    bool takenDamage = false;

    IDamageable player;
    Transform target;
    CircleCollider2D circleCollider;
    SpriteRenderer cowSprite;
    public GameObject circleSprite;
    public SpriteRenderer circleSpriteRenderer;
    Color originalColor;
    Color angryColor;

    Animator animator;

    void Start()
    {
        player = FindObjectOfType<Player>().gameObject.GetComponent<IDamageable>();
        target = FindObjectOfType<Player>().transform;
        cowSprite = GetComponent<SpriteRenderer>();
        originalColor = cowSprite.color;
        angryColor = Color.red;
        animator = GetComponent<Animator>();
        float radiusCircle = GetComponent<CircleCollider2D>().radius;
        circleSprite.transform.localScale = new Vector3((radiusCircle * 2), (radiusCircle * 2), 1);
    } // Start

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
           playerInRange = true;
            StartCoroutine( AngerManagement() ); 
        }
        
    } // set attack time if player is in range

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            playerInRange = false;
            takenDamage = false;
            StartCoroutine( AngerManagement() ); 
        }
        
    } // let update know if the player has escaped the cow

    IEnumerator AngerManagement()
    {   
        while(angryPercent <= 1 && playerInRange)
        {
            cowSprite.color = Color.Lerp(originalColor, angryColor, angryPercent);
            circleSpriteRenderer.color = new Color(0.2196079f, 0.2196079f, 0.2196079f, (angryPercent * 0.1f));
            angryPercent += Time.deltaTime * reactionTime;
            yield return null;
        } // Get angry when da human is intruding on his private time

        if(angryPercent >= 1 && playerInRange && !takenDamage)
        {
            player.TakeDamage(damage);
            takenDamage = true;
            animator.SetBool("isAttacking", true);
            yield return new WaitForSeconds(0.87f); // it works trust me
            animator.SetBool("isAttacking", false);
        } // Attack player and play animation

        while(angryPercent >= 0 && !playerInRange)
        {
            cowSprite.color = Color.Lerp(originalColor, angryColor, angryPercent);
            circleSpriteRenderer.color = new Color(0.2196079f, 0.2196079f, 0.2196079f, (angryPercent * 0.1f));
            angryPercent -= Time.deltaTime * reactionTime;
            yield return null;
        } // Calm down while the player is not near

        yield break;
    } // Attack the player after changing color to show anger.

} // End of class MotherCowLogic