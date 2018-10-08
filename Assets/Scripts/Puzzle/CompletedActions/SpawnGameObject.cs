using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGameObject : MonoBehaviour {

    public GameObject prefab;
    private CheckAllPlaces checkAllPlaces;
	void Start () {
        checkAllPlaces = GetComponent<CheckAllPlaces>();
        checkAllPlaces.OnComplete += Spawn;
	}
    private void OnDestroy()
    {
        checkAllPlaces.OnComplete -= Spawn;
    }

    // Update is called once per frame
    void Spawn () {
        Instantiate(prefab, transform.position+prefab.transform.position, prefab.transform.rotation);
	}
}
