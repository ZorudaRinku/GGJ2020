using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class Movement : MonoBehaviour
{
    public static bool Canmove = true;
    public static bool isdead = false;
    [SerializeField]
    GameObject positionTester;
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
                if (Physics2D.OverlapCircle(new Vector2(transform.position.x , transform.position.y + 1), 0.2f) != null)
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



        }

    }

    private IEnumerator Wait(float waitTime)
    {

        yield return new WaitForSeconds(waitTime);


    }

    /// <summary>
    /// if manages to exit the boat, sends to center
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Ship")
        {
            Movement.Canmove = false;

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
