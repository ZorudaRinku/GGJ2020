using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Gold : MonoBehaviour
{

    TextMeshProUGUI goldCount;

    // Start is called before the first frame update
    void Start()
    {
        goldCount = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        goldCount.text = "Gold: " + gameManager.coins.ToString();
    }
}
