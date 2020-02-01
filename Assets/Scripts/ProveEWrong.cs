using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProveEWrong : MonoBehaviour
{
    Vector2 weewoo = new Vector2();
    // Start is called before the first frame update
    void Start()
    {
           
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            weewoo.y = 1;
        }else if(Input.GetKeyDown(KeyCode.S)){
            weewoo.y = -1;
        }
        else
        {
            weewoo = Vector2.zero;
        }

        transform.position = new Vector3(transform.position.x + weewoo.x, transform.position.y + weewoo.y, 0);
    }
}
