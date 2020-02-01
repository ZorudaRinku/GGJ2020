using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class Movement : MonoBehaviour
{
    bool Canmove = true;
    bool isdead = false;
    private IEnumerator coroutine;
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

        {
            if (Canmove == true)
            {

                if (Input.GetKeyDown(KeyCode.A))
                {
                    transform.position = new Vector2(transform.position.x - 1, transform.position.y);
                        coroutine = Wait(1 * Time.deltaTime);
                        if (isdead == true)
                        {
                            transform.position = new Vector2(transform.position.x + 1, transform.position.y);
                        }

                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    transform.position = new Vector2(transform.position.x + 1, transform.position.y);
                    if (isdead == true)
                    {
                        transform.position = new Vector2(transform.position.x - 1, transform.position.y);
                    }
                }
                if (Input.GetKeyDown(KeyCode.W))
                {
                    transform.position = new Vector2(transform.position.x, transform.position.y + 1);
                    if (isdead == true)
                    {
                        transform.position = new Vector2(transform.position.x, transform.position.y - 1);
                    }
                }
                if (Input.GetKeyDown(KeyCode.S))
                {
                    transform.position = new Vector2(transform.position.x, transform.position.y - 1);
                    
                    if (isdead == true)
                    {
                        transform.position = new Vector2(transform.position.x + 1, transform.position.y + 1);
                    }
                }

            }

        }

    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Ship")
        {
            Canmove = false;
            isdead = true;
        }
        else
        {
            Debug.Log("I am touching the ship");
            Canmove = true;
        }
    }
    private IEnumerator Wait(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
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
