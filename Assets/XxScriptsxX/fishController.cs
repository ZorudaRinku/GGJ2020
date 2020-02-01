using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishController : MonoBehaviour
{
    [SerializeField] public Transform heartShip;

    private Rigidbody2D rb2D;
    public float thrust = 50f;

    public float rotateSpeed = 10;

    public float attackSpeedSeconds = 3;

    //used for aiming at heart
    Vector3 targetDirection;

    // Start is called before the first frame update
    IEnumerator Start() //void Start()
    {
        // Determine which direction to rotate towards
        targetDirection = heartShip.position - transform.position;
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

        yield return StartCoroutine("waitAndLaunch");
    }

    // Update is called once per frame
    void Update()
    {
     //Change rotation towards heart
        // Determine which direction to rotate towards
        targetDirection = heartShip.position - transform.position;
        // The step size is equal to speed times frame time.
        float singleStep = rotateSpeed * Time.deltaTime;
        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
        // Draw a ray pointing at our target in
        //Debug.DrawRay(transform.position, newDirection, Color.red);
        
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

}
