using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAllPlaces : MonoBehaviour {

    public GameObject enemy;
    public GameObject puzzleParent;
    private ObjectFinalSpot[] objectFinalSpots;

	// Use this for initialization
	void Start () {
        objectFinalSpots = puzzleParent.GetComponentsInChildren<ObjectFinalSpot>();
	}
	
	// Update is called once per frame
	public void CheckAll () {
		foreach(ObjectFinalSpot objFS in objectFinalSpots)
        {
            if (!objFS.isFull) return;
        }
        Instantiate(enemy, transform);
	}
}
