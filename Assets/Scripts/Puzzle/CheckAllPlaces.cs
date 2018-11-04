using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CheckAllPlaces : MonoBehaviour, ITrigger
{

    public event Action OnComplete = delegate { };
    private List<ITrigger> objectFinalSpots;

    public ITrigger Parent { get; set; }

    void Start()
    {
        objectFinalSpots = new List<ITrigger>(GetComponentsInChildren<ITrigger>().Where(e => e.Parent == null && e != this));
        foreach (var spot in objectFinalSpots)
        {
            spot.Parent = this;
        }
    }

    public void OnTrigger(GameObject go)
    {
        objectFinalSpots.Remove(go.GetComponent<ITrigger>());
        if (objectFinalSpots.Count == 0)
        {
            OnComplete();
            if (Parent != null)
            {
                Parent.OnTrigger(gameObject);
            }
        }
    }

    public bool Check(GameObject go)
    {
        return objectFinalSpots.Contains(go.GetComponent<ITrigger>());
    }
}
