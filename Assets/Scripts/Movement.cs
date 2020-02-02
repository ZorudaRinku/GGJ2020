﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{
    public static bool Canmove = true;
    public static bool isdead = false;
    private IEnumerator coroutine;
    int buildTimerLeft = 90;
    int buildTimerRight = 90;
    int buildTimerCannon = 380;
    int repairtimer = 30;
    GameObject currentTile;
    [SerializeField]
    GameObject newTile;
    [SerializeField]
    GameObject newCannon;
    [SerializeField]
    GameObject RepairTile;
    bool canBuild = true;
    bool canRepair = true;
    bool repairing = false;
    [SerializeField]
    GameObject Building;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        //float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");
        //if(moveVertical > 0)
        //{
        //    transform.position = new Vector2(transform.position.x, transform.position.y + 1);
        //}
        //if (moveVertical < 0)
        //{
        //    transform.position = new Vector2(transform.position.x, transform.position.y - 1);
        //}
        //if (moveHorizontal > 0)
        //{
        //    transform.position = new Vector2(transform.position.x + 1, transform.position.y);
        //}
        //if(moveHorizontal < 0 )
        //{
        //    transform.position = new Vector2(transform.position.x - 1, transform.position.y);
        //}

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (Physics2D.OverlapCircle(new Vector2(transform.position.x - 1, transform.position.y), 0.2f) != null)
            {
                transform.position = new Vector2(transform.position.x - 1, transform.position.y);
            }


        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (Physics2D.OverlapCircle(new Vector2(transform.position.x + 1, transform.position.y), 0.2f) != null)
            {
                transform.position = new Vector2(transform.position.x + 1, transform.position.y);
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y + 1), 0.2f) != null)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + 1);
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y - 1), 0.2f) != null)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - 1);
            }
        }
        //GameObject tile = Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y), 0.2f).gameObject;

        if (canBuild)
        {

            if (buildTimerLeft <= 0 && gameManager.coins >= 500)
            {
                if (Physics2D.OverlapCircle(new Vector2(transform.position.x - 1, transform.position.y), 0.2f) == null)
                {
                    Instantiate(newTile, new Vector3(transform.position.x - 1, transform.position.y, 0), transform.rotation);
                    canBuild = false;
                    gameManager.coins -= 500;
                }

            }
            if (buildTimerRight <= 0 && gameManager.coins >= 500)
            {
                if (Physics2D.OverlapCircle(new Vector2(transform.position.x + 1, transform.position.y), 0.2f) == null)
                {
                    Instantiate(newTile, new Vector3(transform.position.x + 1, transform.position.y, 0), transform.rotation);
                    canBuild = false;
                    gameManager.coins -= 500;
                }

            }
            if (buildTimerCannon <= 0 && gameManager.coins >= 1500)
            {
                    canBuild = false;
                    gameManager.coins -= 1500;
                    StartCoroutine(Wait(3));
            }
        }
        if(canRepair)
        {
            if (repairtimer <= 0)
            {
                if (currentTile.GetComponent<Health>().health == 1 && gameManager.coins >= 200)
                {  
                    currentTile.GetComponent<Health>().health++;
                    repairtimer = 30;
                    gameManager.coins -= 200;
                    canBuild = false;
                }
            }
        }

<<<<<<< HEAD
        if (Input.GetKeyUp(KeyCode.Space))
        {
            buildTimerLeft = 90;
            buildTimerRight = 90;
            buildTimerCannon = 380;
            repairtimer = 30;
            foreach (GameObject build in GameObject.FindGameObjectsWithTag("Build"))
            {
                Destroy(build);
            }
            canBuild = true;
            repairing = false;
        }

<<<<<<< HEAD
        if (buildTimerRight == 0 || buildTimerLeft == 0 || buildTimerCannon == 1 || repairtimer == 1)
        {
            foreach (GameObject build in GameObject.FindGameObjectsWithTag("Build"))
=======

            {
                buildTimerRight--;
            }
            else if (Input.GetKey(KeyCode.Space) )
>>>>>>> 38dd801cfdff5ca0d7839e76dc89865ac2c6fdc0
            {
                Destroy(build);
            }
        }

        if ((Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.Space)) || Input.GetKey(KeyCode.Q))
        {
            buildTimerLeft--;
        }

        else if ((Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.Space)) || Input.GetKey(KeyCode.E))
        {
            buildTimerRight--;
        }
        else if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.R)) && currentTile.GetComponent<Health>().health == 2 && !repairing)
        {
            Debug.Log(buildTimerCannon);
            buildTimerCannon--;
        }
        else if (Input.GetKey(KeyCode.Space) && currentTile.GetComponent<Health>().health == 1)
        {
            repairing = true;
            Debug.Log(repairtimer);
            repairtimer--;
        }

        if (buildTimerCannon == 379 && gameManager.coins >= 1500)
        {
            Instantiate(Building, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
        }

        if (buildTimerLeft == 89 && gameManager.coins >= 500)
        {
            Instantiate(Building, new Vector3(transform.position.x - 1, transform.position.y, 0), transform.rotation);
        }

        if (buildTimerRight == 89 && gameManager.coins >= 500)
        {
            Instantiate(Building, new Vector3(transform.position.x + 1, transform.position.y, 0), transform.rotation);
        }

        if (repairtimer == 29 && gameManager.coins >= 200)
        {
            Instantiate(Building, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
        }

    }

    private IEnumerator Wait(float waitTime)
    {
        Instantiate(newCannon, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
        buildTimerCannon = 380;

        yield return new WaitForSeconds(waitTime);

    }

    /// <summary>
    /// if manages to exit the boat, sends to center
    /// </summary>
    /// <param name="other"></param>
    /// 
    /*void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Ship")
        {
            transform.position = new Vector3(1.5f, -4.5f, 0f);
        }
        
    }
    */
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Ship")
        {
            currentTile = other.transform.gameObject;
            Debug.Log(currentTile);
            Debug.Log(currentTile.GetComponent<Health>().health);
            if (currentTile.GetComponent<Health>().health != 2)
            {
                canBuild = false;

            }
            if (currentTile.GetComponent<Health>().health == 1)
            {
                canRepair = true;
            }
            else
            {
                canRepair = false;
            }
        }


    }

    //private void OnColliderEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "Ship")
    //    {
    //        Debug.Log("I am touching the ship");
    //        Canmove = true;
    //    }
    //    else
    //    {
    //        Canmove = false;
    //        isdead = true;
    //    }
    //}

}
