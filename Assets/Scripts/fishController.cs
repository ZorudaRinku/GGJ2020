﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishController : MonoBehaviour
{
    GameObject heartShip;

    private Rigidbody2D rb2D;

    [SerializeField] float thrust = 50f;

    [SerializeField] float rotateSpeed = 10;

    [SerializeField] float attackSpeedSeconds = 3;

    bool noHeart = false;
    //used for aiming at heart
    Vector3 targetDirection;

    // Start is called before the first frame update
    void Awake() 
    {
        transform.Rotate(0, 0, 0, Space.World);
        if (GameObject.FindGameObjectWithTag("Respawn") != null)
        {
            noHeart = true;

            heartShip = GameObject.FindGameObjectWithTag("Respawn"); //yo dumbass remember to change this

            // Determine which direction to rotate towards
            targetDirection = heartShip.transform.position - transform.position;
            // The step size is equal to speed times frame time.
            float singleStep = rotateSpeed * Time.deltaTime;
            // Rotate the forward vector towards the target direction by one step
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
            // Draw a ray pointing at our target in
            //Debug.DrawRay(transform.position, newDirection, Color.red);

            //Launch fish at boat's heart
            rb2D = gameObject.GetComponent<Rigidbody2D>();
            //Fire fish
            rb2D.AddForce(transform.forward * thrust);

            StartCoroutine(waitAndLaunch());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (noHeart)
        {
            //Change rotation towards heart
            // Determine which direction to rotate towards
            targetDirection = heartShip.transform.position - transform.position;
            // The step size is equal to speed times frame time.
            float singleStep = rotateSpeed * Time.deltaTime;
            // Rotate the forward vector towards the target direction by one step
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
            // Draw a ray pointing at our target in
            //Debug.DrawRay(transform.position, newDirection, Color.red);
        }
    }

    IEnumerator waitAndLaunch()
    {
        // suspend execution for x seconds
        yield return new WaitForSeconds(attackSpeedSeconds);

        //Fire fish
        rb2D.AddForce(targetDirection * thrust);

        // Start function as a coroutine
        yield return StartCoroutine("waitAndLaunch");
    }

    void OnCollisionEnter2D(Collision2D fishCollision)
    {
        if (fishCollision.transform.tag == "Finish")
        {
            Destroy(fishCollision.transform.gameObject);
            Destroy(gameObject);
        }
        else if (fishCollision.transform.tag == "Respawn")
        {
            Destroy(fishCollision.transform.gameObject);
            Destroy(gameObject);
            Debug.Log("Will end game and restart to menu");
        }
    }

}