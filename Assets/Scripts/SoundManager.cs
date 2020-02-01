using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void SetMusic(float value)
    {
        this.transform.Find("Music").GetComponent<AudioSource>().volume = value;
    }

    public void SetSound(float value)
    {
        this.transform.Find("Sound").GetComponent<AudioSource>().volume = value;
    }
}
