using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafLogic : MonoBehaviour
{
    public float leafSpeed;
    public int minScreen;
    public int maxY;
    public int minY;
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

        // check if below screen, if so, remove and respawn
        Vector3 pos = transform.position;
        if (pos.y < minScreen)
        {
            pos.y = Random.Range(minY, maxY);
        }
    }
}
