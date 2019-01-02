using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderEnabler : MonoBehaviour
{

    public float Time = 1;
    public float RepeatTime = 1;
    private Collider coll;

    void Start ()
    {
        coll = GetComponent<Collider>();
        InvokeRepeating("EnableColl", Time, RepeatTime);
	}

    void EnableColl()
    {
        coll.enabled = !coll.enabled;
    }

}
