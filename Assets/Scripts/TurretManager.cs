using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : MonoBehaviour
{
    [SerializeField]
    GameObject turret;
    [SerializeField]
    GameObject cannonParent;
    [SerializeField]
    GameObject Bullet;
    GameObject anchor;
    static public List<GameObject> cannons = new List<GameObject>();
    static public GameObject currentCannon;
    int currentCannonIndex;
    public static bool turretMode = true;
    bool canShoot;
    float anchorMove = .05f;

    public static bool anchorMode = false;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(wait());
        anchor = GameObject.FindWithTag("Anchor");
        canShoot = true;
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadPlus)) 
        {
            anchorMode = !anchorMode;
            turretMode = !turretMode;
            Debug.Log(anchorMode + " " + turretMode);
            

        }
        if (turretMode)
        {
            if (Input.GetKeyDown(KeyCode.KeypadEnter) && canShoot)
            {
                Instantiate(Bullet, currentCannon.transform.position, transform.rotation);
                canShoot = false;
                StartCoroutine(waitShoot());
            }
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
          
        }
        else if (anchorMode)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                anchor.transform.position = new Vector2(anchor.transform.position.x - anchorMove, anchor.transform.position.y);
                

            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                anchor.transform.position = new Vector2(anchor.transform.position.x + anchorMove, anchor.transform.position.y);
                
            }
            if (Input.GetKey(KeyCode.UpArrow) && anchor.transform.position.y + anchorMove < 0)
            {
                anchor.transform.position = new Vector2(anchor.transform.position.x, anchor.transform.position.y + anchorMove);
                
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                anchor.transform.position = new Vector2(anchor.transform.position.x, anchor.transform.position.y - anchorMove);

                
            }


        }
    }
        

    IEnumerator wait()
    {
        yield return new WaitForSeconds(.5f);
        currentCannon = cannons[0];
        currentCannonIndex = 0;
    }
    IEnumerator waitShoot()
    {
        yield return new WaitForSeconds(.75f);
        canShoot = true;
    }
}
