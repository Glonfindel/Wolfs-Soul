using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour {
    Rigidbody rigid;
    public Vector3 offset;
    // Use this for initialization

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.GetComponent<ObjectFinalSpot>())
        {
            ObjectFinalSpot spot = other.GetComponent<ObjectFinalSpot>();
            if (spot.fitsHere == gameObject)
            {
                spot.isPlaced = true;
                spot.audioSource.PlayOneShot(spot.audioSource.clip);
                gameObject.transform.position = spot.transform.position+offset;
                Destroy(rigid);
                gameObject.isStatic = true;
                FindObjectOfType<CheckAllPlaces>().CheckAll();
            }
        }
    }
}
