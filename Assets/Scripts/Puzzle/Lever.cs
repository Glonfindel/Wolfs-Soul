using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour,ITrigger {

    public ITrigger Parent { get; set; }

    public GameObject GameObject
    {
        get { return gameObject; }
    }

    public bool Check(GameObject go)
    {
        return go.GetComponentInParent<CharacterController>()!=null;
    }

    public void OnTrigger(GameObject go)
    {
        if (Parent != null && Parent.Check(gameObject))
        {
            Parent.OnTrigger(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var trigger = other.GetComponent<Collider>();
        if (trigger != null && Check(trigger.gameObject))
        {
            OnTrigger(gameObject);
        }
    }
}
