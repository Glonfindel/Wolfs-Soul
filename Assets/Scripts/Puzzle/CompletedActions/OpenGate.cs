using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGate : MonoBehaviour
{

    public GameObject gate;
    private CheckAllPlaces checkAllPlaces;

    void Start()
    {
        checkAllPlaces = GetComponent<CheckAllPlaces>();
        checkAllPlaces.OnComplete += Open;
    }

    private void OnDestroy()
    {
        checkAllPlaces.OnComplete -= Open;
    }

    private void Open()
    {
        gate.SetActive(false);
    }
}
