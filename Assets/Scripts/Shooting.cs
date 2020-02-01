using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    float speed = 10f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Vector3 bulletForce = TurretManager.currentCannon.transform.up * speed;
        Debug.Log(TurretManager.currentCannon.transform.forward);
        GetComponent<Rigidbody2D>().velocity = bulletForce;
    }

    // Update is called once per frame
    void Update()
    {

        
        //Debug.Log(GetComponent<Rigidbody2D>().velocity);
    }
}
