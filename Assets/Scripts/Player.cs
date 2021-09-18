using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof( Rigidbody2D))]
public class Player: LivingEntity
{   
    public float speed = 6.0f;
    
    Rigidbody2D player;
    
    protected override void Start()
    {
        base.Start();
        player = gameObject.GetComponent<Rigidbody2D>();
    } // Start is called before the first frame update

    void FixedUpdate()
    {
        Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        player.MovePosition(player.position += (direction * speed * Time.deltaTime)); 
    } // End of Fixed Update
} // End of class 