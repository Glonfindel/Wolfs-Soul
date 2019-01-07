using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundVolume : MonoBehaviour {

    public void Awake()
    {
        GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Sound", 0.5f);
    }
}
