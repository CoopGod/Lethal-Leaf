using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof( Rigidbody2D))]
public class Player: MonoBehaviour
{   
    public float speed = 6.0f; 
    Rigidbody2D player;
    
    void Start()
    {
        player = gameObject.GetComponent<Rigidbody2D>();
    } // Start is called before the first frame update

    void Update()
    {
        Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        player.MovePosition(player.position += (direction * speed * Time.deltaTime));
        
    } // Update is called once per frame
} // End of class