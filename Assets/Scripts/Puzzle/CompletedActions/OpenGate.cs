using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGate : MonoBehaviour
{

    public GameObject gate;
    private CheckAllObjectives checkAllObjectives;

    void Awake()
    {
        checkAllObjectives = GetComponent<CheckAllObjectives>();
        checkAllObjectives.OnComplete += Open;
    }

    private void OnDestroy()
    {
        checkAllObjectives.OnComplete -= Open;
    }

    private void Open()
    {
        gate.GetComponent<Animator>().Play("Open");
    }
}
