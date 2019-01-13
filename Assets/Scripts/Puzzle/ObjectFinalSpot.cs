using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFinalSpot : MonoBehaviour, ITrigger
{
    public MovingObject fitsHere; //Gameobject ktory ma tu byc docelowo
    [NonSerialized] public bool isFull;
    private AudioSource soundOnTrigger;
    public GameObject GameObject
    {
        get { return gameObject; }
    }

    public bool Complete { get; set; }
    public ITrigger Parent { get; set; }

    private void Start()
    {
        soundOnTrigger = Resources.Load<AudioSource>("SFX/ObjectPlaced");
    }

    public bool Check(GameObject go)
    {
        return go == fitsHere.gameObject;
    }

    public void OnTrigger(GameObject go)
    {
        isFull = true;
        Instantiate(soundOnTrigger, transform.position, Quaternion.identity);
        if (Parent != null && Parent.Check(gameObject))
        {
            Parent.OnTrigger(gameObject);
            Complete = true;
        }
    }
}


