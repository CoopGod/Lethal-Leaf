using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : MonoBehaviour, IDamageable
{
    public float startHealth;
    protected float health;
    protected bool dead;

    public event System.Action OnDeath;

    protected virtual void Start()
    {
        health = startHealth;
    } // Start is called once at the start

    public virtual void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        } // The bitch is dead
    } // Take some damage

    [ContextMenu ("Self Destruct")]
    protected void Die()
    {
        if(OnDeath != null){ Debug.Log("OnDeath called"); OnDeath(); }
        Destroy(gameObject);
    } // That bitch is officially dead

} // End of class Living Entity