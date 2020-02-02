using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GoldCOunt : MonoBehaviour
{
    TextMeshProUGUI gameTimerText;
    float gameTimer;
    // Start is called before the first frame update
    void Start()
    {
        gameTimer = 0;
        gameTimerText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        gameTimer += Time.deltaTime;
        
        gameTimerText.text = "Time: " + ((int)gameTimer).ToString();
    }
}
