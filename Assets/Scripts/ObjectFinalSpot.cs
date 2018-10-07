using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFinalSpot : MonoBehaviour {

    public GameObject fitsHere; //Gameobject ktory ma tu byc docelowo
    [HideInInspector] public bool isPlaced=false;
    [HideInInspector] public AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
}
