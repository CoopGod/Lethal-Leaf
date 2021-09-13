using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (CircleCollider2D))]
public class LeafPile : MonoBehaviour
{
    public GameObject leaf;
    public float leafMinSize = 25f;
    public float leafMaxSize = 40f;
    public float timeToRake = 5f;
    public int numberOfLeaves = 50;

    private float rakingTime = 0f;
    private float rakedPercent = 0f;
    
    public LayerMask leafLayer;

    CircleCollider2D circleCollider;
    List<GameObject> leaves = new List<GameObject>();
    Transform center;

    void Start()
    {
        circleCollider = gameObject.GetComponent<CircleCollider2D>();
        center = gameObject.transform;
        SpawnLeaves();
    } // Start is called before the first frame update

    void SpawnLeaves()
    {
        for(int i = 0; i < numberOfLeaves; i++)
        {
            (float, float) randomXY = RandomPoint();
            float randomSize = Random.Range(leafMinSize, leafMaxSize);
            GameObject newLeaf = Instantiate(leaf, new Vector3(randomXY.Item1, randomXY.Item2, leaf.transform.position.z), Quaternion.identity);
            newLeaf.transform.parent = gameObject.transform;
            newLeaf.transform.rotation = Quaternion.Euler(0,0, Random.Range(0,360));
            newLeaf.transform.localScale = new Vector3(randomSize, randomSize, leaf.transform.position.z);
            leaves.Add(newLeaf); // Add the leaves to a list so I can move them later.
        } // Spawn the number of leaves desired at a random position and rotation within the circle collider of this object

    } // Spawn the leaves

    (float, float) RandomPoint()
    {
        float r = circleCollider.radius * Mathf.Sqrt(Random.Range(0f, 1f));
        float theta = Random.Range(0f,1f) * 2 * Mathf.PI;
        float x = gameObject.transform.position.x + r * Mathf.Cos(theta);
        float y = gameObject.transform.position.y + r * Mathf.Sin(theta);
        return (x, y);
    } // Choose a random point within the circle

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider == FindObjectOfType<Player>().GetComponent<BoxCollider2D>())
        {
            StartCoroutine( RakeLeaves() );
        } // Runs if the collider that entered was the player
    } // Upon something entering the object range

    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider == FindObjectOfType<Player>().GetComponent<BoxCollider2D>())
        {
            print("Stopping Coroutine");
            StopCoroutine( RakeLeaves() );
        } // Runs if the collider that entered was the player
    } // Upon something exiting the collider range

    void MoveLeaves(float percentageToMove)
    {
        for(int i = 0; i < leaves.Count; i++)
        {
            Transform leaf = leaves[i].transform;
            float distance = Vector2.Distance(center.position, leaf.position);
            leaf.position = Vector2.MoveTowards(leaf.position, center.position, distance * percentageToMove);
        } // Loop through all the leaves in the leaves list
    } // Move the leaves toward the required direction when this fucntion is called

    IEnumerator RakeLeaves()
    {
        while(rakingTime < timeToRake)
        {
            float oldPercent;
            float percentageToMove;
            rakingTime += Time.deltaTime;
            oldPercent = rakedPercent;
            rakedPercent = rakingTime / timeToRake;
            percentageToMove = rakedPercent - oldPercent;
            MoveLeaves(percentageToMove);
            yield return null;
        } // Run until the leaves are finished being raked

        print("The player has finished raking this pile.");
        yield return null;
    } // Rake the leaves by pulling them towards the center.
} // End of class