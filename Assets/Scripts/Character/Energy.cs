using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour {

    public float CurrentEnergy
    {
        get
        {
            return energy;
        }
        set
        {
            energy = Mathf.Clamp(value, 0, maxEnergy);
            OnValueChange();
            if (energy >= maxEnergy || energy <= 0)
            {
                OnFullValue();
            }
        }
    }
    private float maxEnergy = 100;
    private float energy;
    public event Action OnValueChange = delegate { };
    public event Action OnFullValue = delegate { };
    public float EnergyAsPercentage { get { return energy / maxEnergy; } }
}
