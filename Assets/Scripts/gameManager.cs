using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public static bool gameover = false;
    public static int coins;
    [SerializeField] GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        coins = 1500;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameover && !canvas.active)
        {
            canvas.SetActive(true);
        } else if (!gameover && canvas.active)
        {
            canvas.SetActive(false);
        }
    }
}
