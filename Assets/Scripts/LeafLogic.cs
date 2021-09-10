using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafLogic : MonoBehaviour
{
    public float leafSpeed;
    Rigidbody2D leaf;

    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0, 0, Random.Range(0, 360), Space.Self);
        leaf = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        leaf.MovePosition(leaf.position += (Vector2.down * leafSpeed * Time.deltaTime));
    }
}
