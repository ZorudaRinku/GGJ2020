using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{

    TextMeshProUGUI gameTimerText;
    int gameTimer;

    // Start is called before the first frame update
    void Start()
    {
        gameTimer = 0;
        gameTimerText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        gameTimer++;
        gameTimerText.text = "Time: " + ((int)Time.time).ToString();
    }
}