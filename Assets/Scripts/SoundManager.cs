using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Sounds
{
    CANNON,
    COIN,
    REPAIR,
    REPAIRTURRET,
    TILEBREAK,
    SONG
}

public class SoundManager : MonoBehaviour
{
    [SerializeField] GameObject music;
    [SerializeField] GameObject sound;
    Dictionary<Sounds, AudioClip> soundsDict = new Dictionary<Sounds, AudioClip>();

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        //sets up sound dictionary
        soundsDict.Add(Sounds.CANNON, Resources.Load<AudioClip>("Sound/cannon"));
        soundsDict.Add(Sounds.COIN, Resources.Load<AudioClip>("Sound/coin"));
        soundsDict.Add(Sounds.REPAIR, Resources.Load<AudioClip>("Sound/repair"));
        soundsDict.Add(Sounds.REPAIRTURRET, Resources.Load<AudioClip>("Sound/repairLong"));
        soundsDict.Add(Sounds.TILEBREAK, Resources.Load<AudioClip>("Sound/tileBreak"));
    }

    public void SetMusic(float value)
    {
        this.transform.Find("Music").GetComponent<AudioSource>().volume = value;
    }

    public void SetSound(float value)
    {
        this.transform.Find("Sound").GetComponent<AudioSource>().volume = value;
    }

    public void PlayMusic (Sounds song)
    {
        music.GetComponent<AudioSource>().PlayOneShot(soundsDict[song],1);
    }
    public void PlaySound(Sounds sfx)
    {
        sound.GetComponent<AudioSource>().PlayOneShot(soundsDict[sfx],1);
    }
}
