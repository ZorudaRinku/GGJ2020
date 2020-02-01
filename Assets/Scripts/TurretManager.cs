using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : MonoBehaviour
{
    [SerializeField]
    GameObject turret;
    [SerializeField]
    GameObject cannonParent;
    GameObject anchor;
    static public List<GameObject> cannons = new List<GameObject>();
    static public GameObject currentCannon;
    int currentCannonIndex;
    bool turretMode;
    float anchorMove = .01f;
    
    bool anchorMode;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(wait());
        anchor = GameObject.FindWithTag("Anchor");
        anchor.transform.position = new Vector3(transform.position.x, transform.position.y - 5, 0);
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadPlus)) 
        {

        }
        if (turretMode)
        {
            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                if (currentCannon == cannons[0])
                {
                    currentCannon = cannons[cannons.Count - 1];
                    currentCannonIndex = cannons.Count - 1;
                }
                else
                {
                    currentCannon = cannons[currentCannonIndex - 1];
                }
            }
            if (Input.GetKeyDown(KeyCode.Keypad3))
            {
                if (currentCannon == cannons[cannons.Count - 1])
                {
                    currentCannon = cannons[0];
                    currentCannonIndex = 0;
                }
                else
                {
                    currentCannon = cannons[currentCannonIndex + 1];
                }
            }
            if (Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                Instantiate(turret, new Vector3(Random.Range(-20, 20), Random.Range(-20, 20), 0), transform.rotation);
            }
        }
        else if (anchorMode)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                anchor.transform.position = new Vector2(transform.position.x - anchorMove, transform.position.y);
                

            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                anchor.transform.position = new Vector2(transform.position.x + anchorMove, transform.position.y);
                
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                anchor.transform.position = new Vector2(transform.position.x, transform.position.y + anchorMove);
                
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                anchor.transform.position = new Vector2(transform.position.x, transform.position.y - anchorMove);

                
            }


        }
    }
        

    IEnumerator wait()
    {
        yield return new WaitForSeconds(.5f);
        currentCannon = cannons[0];
        currentCannonIndex = 0;
    }
}
