using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    Vector3 rotationTool = new Vector3();
    float rotationValue = 0.5f;
    Color currentColor;
    
    void Start()
    {
        
        TurretManager.cannons.Add(transform.gameObject);
        currentColor = this.GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        if (TurretManager.turretMode)
        {
            if (this.transform.gameObject == TurretManager.currentCannon)
            {
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    rotationTool.z = rotationValue;

                }
                else if (Input.GetKey(KeyCode.RightArrow))
                {
                    rotationTool.z = -rotationValue;
                }
                else
                {
                    rotationTool = Vector3.zero;
                }

                transform.eulerAngles = new Vector3(transform.eulerAngles.x + rotationTool.x, transform.eulerAngles.y + rotationTool.y, transform.eulerAngles.z + rotationTool.z);
                currentColor.a = 1;
            }
            else
            {
                currentColor.a = .5f;
            }
        }
        
        else
        {
            currentColor.a = .5f;

        }
        this.GetComponent<SpriteRenderer>().color = currentColor;
       
    }
    void OnTriggerExit2D(Collider2D other)
    {

        Destroy(gameObject);


    }
}
