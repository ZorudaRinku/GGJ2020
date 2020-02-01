using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : MonoBehaviour
{
    [SerializeField]
    GameObject turret;
    [SerializeField]
    GameObject cannonParent;
    static public List<GameObject> cannons = new List<GameObject>();
    static public GameObject currentCannon;
    int currentCannonIndex;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(wait());
        
        Debug.Log(cannons.Count);
    }

    // Update is called once per frame
    void Update()
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

    IEnumerator wait()
    {
        yield return new WaitForSeconds(.5f);
        currentCannon = cannons[0];
        currentCannonIndex = 0;
    }
}
