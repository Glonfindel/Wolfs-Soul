using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicVolume : MonoBehaviour {

    public void Awake()
    {
        GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Music", 0.5f);
    }
}
