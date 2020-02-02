using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D anchorCollision)
    {
        if (anchorCollision.transform.tag == "Anchor")//destroys coin gives coin
        {
            gameManager.coins += 500;
            Destroy(gameObject);
            Debug.Log(gameManager.coins);
            SoundManager.PlaySound(Sounds.COIN);
        }
        if (anchorCollision.transform.tag == "Player")//destroys coin gives coin
        {
            gameManager.coins += 500;
            Destroy(gameObject);
            Debug.Log(gameManager.coins);
        }
    }
}
