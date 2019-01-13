﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CheckAllObjectives : MonoBehaviour, ITrigger
{

    public event Action OnComplete = delegate { };
    private List<ITrigger> objectives = new List<ITrigger>();

    public bool Complete { get; set; }
    public ITrigger Parent { get; set; }

    public GameObject GameObject
    {
        get { return gameObject; }
    }

    void Awake()
    {
        objectives.AddRange(GetComponentsInChildren<ITrigger>(true).Where(e => e.Parent == null && e != this && e.GameObject.transform.parent == GameObject.transform));
        foreach (var obj in objectives)
        {
            obj.Parent = this;
        }
    }

    public void OnTrigger(GameObject go)
    {
        objectives.Remove(go.GetComponent<ITrigger>());
        if (objectives.Count == 0)
        {
            OnComplete();
            if (Parent != null)
            {
                Parent.OnTrigger(gameObject);
                Complete = true;
            }
        }
    }

    public bool Check(GameObject go)
    {
        return objectives.Contains(go.GetComponent<ITrigger>());
    }

    public void AddObjective(ITrigger objective)
    {
        objectives.Add(objective);
        objective.Parent = this;
    }
}
