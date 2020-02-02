using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishSpawner : MonoBehaviour
{
    [SerializeField] float spawnSpeedSecondsLow = 9f;
    [SerializeField] float spawnSpeedSecondsHigh = 15f;
    [SerializeField] float spawnRadiusLow = 5f;
    [SerializeField] float spawnRadiusHigh = 10f;
    [SerializeField] float spawnMultiplier = 1f;
    [SerializeField] GameObject fishPrefab;
    [SerializeField] Transform heartShip;
    bool canCo = true;

    // Start is called before the first frame update
    void Start() //void Start()
    {
        spawnMultiplier = 1f;
        StartCoroutine(waitAndSpawn());
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canCo)
        {
            StartCoroutine(difficultyCurve());
            canCo = false;
        }

    }

    IEnumerator waitAndSpawn()
    {
        // start timer for spawnSpeedSeconds divided byt he difficulty multiplier
        float spawnTimeSeconds = Random.Range(spawnSpeedSecondsLow, spawnSpeedSecondsHigh);
        yield return new WaitForSeconds(spawnTimeSeconds / spawnMultiplier);
        Debug.Log(spawnMultiplier);

        //spawn fish in a semicircle from the heart to the water
        // code found from forum https://answers.unity.com/questions/714835/best-way-to-spawn-prefabs-in-a-circle.html 
        Vector3 center = heartShip.position;
        float spawnRadius = Random.Range(spawnRadiusLow, spawnRadiusHigh);
        Vector3 position = RandomCircle(center, spawnRadius);
        Quaternion rotation = Quaternion.FromToRotation(Vector3.forward, center - position);
        Quaternion fixedRotation = new Quaternion(0, 0, rotation.z, 1);
        Instantiate(fishPrefab, position, fixedRotation);

        // Start function as a coroutine
        yield return StartCoroutine("waitAndSpawn");
    }

    IEnumerator difficultyCurve()
    {
        yield return new WaitForSeconds(5);
        spawnMultiplier += .1f;
        canCo = true;


    }

    Vector3 RandomCircle (Vector3 center, float radius)
    {
        float angle = Random.value * 180  + 90;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(angle * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(angle * Mathf.Deg2Rad);
        pos.z = center.z;
        return pos;
    }
}
