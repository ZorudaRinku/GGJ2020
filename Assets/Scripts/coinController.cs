using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinController : MonoBehaviour
{
    private Rigidbody2D rb2D;

    [SerializeField] GameObject heartShip;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > heartShip.transform.position.y)
        {
            rb2D.gravityScale = 0.1f;
        }
        else
        {
            rb2D.gravityScale = -0.1f;
        }
    }

    void OnTriggerEnter2D(Collider2D anchorCollision)
    {
        if (anchorCollision.transform.tag == "Anchor")//destroys coin gives coin
        {
            gameManager.coins += 500;
            Destroy(gameObject);
            Debug.Log(gameManager.coins);
        }
    }
}
