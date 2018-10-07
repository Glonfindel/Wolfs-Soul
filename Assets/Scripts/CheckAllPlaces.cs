using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAllPlaces : MonoBehaviour {

    public GameObject enemy;
    public ObjectFinalSpot[] objectFinalSpots;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void CheckAll () {
		foreach(ObjectFinalSpot objFS in objectFinalSpots)
        {
            if (!objFS.isPlaced) return;
        }
        Instantiate(enemy, transform);
	}
}
