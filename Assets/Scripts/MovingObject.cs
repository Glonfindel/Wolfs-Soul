using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour {
    Rigidbody rigid;
    [Tooltip("y difference between object pivot and ground")]
    public Vector3 offset;
    private GameObject playSound;

    // Use this for initialization

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        playSound = Resources.Load("SFX/ObjectPlaced") as GameObject;
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.GetComponent<ObjectFinalSpot>())
        {
            ObjectFinalSpot spot = other.GetComponent<ObjectFinalSpot>();
            if (spot.fitsHere == gameObject)
            {
                spot.isFull = true;
                Instantiate(playSound, transform);
                gameObject.transform.position = spot.transform.position+offset;
                Destroy(rigid);
                gameObject.isStatic = true;
                FindObjectOfType<CheckAllPlaces>().CheckAll();
            }
        }
    }
}
