using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    TextMeshProUGUI goldCOunt;
    // Start is called before the first frame update
    void Start()
    {
        goldCOunt = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        goldCOunt.text = "Gold : "
 + gameManager.coins.ToString();
    }
}
