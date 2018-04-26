using System.Collections;
using Gamekit2D;
using UnityEngine;

public class spawn : MonoBehaviour{
    public GameObject spawnPrefab;

    public float minSecondsBetweenSpawning = 1.0f;
    public float maxSecondsBetweenSpawning = 2.0f;

    private float savedTime;
    private float secondsBetweenSpawning;

    public float leftMost = -3;
    public float rightMost = 2;

    void Start()
    {
        savedTime = Time.time;
        secondsBetweenSpawning = Random.Range(minSecondsBetweenSpawning, maxSecondsBetweenSpawning);
    }

    // Update is called once per frame
    void Update () {
        if (Time.time - savedTime >= secondsBetweenSpawning) // is it time to spawn again?
        {
            MakeThingToSpawn();
            savedTime = Time.time; // store for next spawn
            secondsBetweenSpawning = Random.Range (minSecondsBetweenSpawning, maxSecondsBetweenSpawning);
        }   
    }

    void MakeThingToSpawn()
    {
        // create a new gameObject
        GameObject clone = Instantiate(spawnPrefab, new Vector3(0, -6, 0), transform.rotation) as GameObject;
        float xPos = Random.Range(leftMost, rightMost);
        clone.transform.Translate(Vector3.right * xPos);
    }
}
