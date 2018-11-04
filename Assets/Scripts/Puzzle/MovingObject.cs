using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour {
    [Tooltip("difference between object pivot and ground")]
    public Vector3 offset;
    private Rigidbody rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        var trigger = other.GetComponent<ITrigger>();
        if (trigger != null && trigger.Check(gameObject))
        {
            trigger.OnTrigger(gameObject);
            transform.position = other.transform.position + offset;
            Destroy(rigid);
        }
    }
}
