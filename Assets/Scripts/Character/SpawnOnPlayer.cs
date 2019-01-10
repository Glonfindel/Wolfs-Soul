using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnPlayer : CombatComponent
{
    public GameObject Prefab;
    private bool initialized;

    protected void OnEnable()
    {
        if (!initialized)
        {
            initialized = true;
            return;
        }
        
        Instantiate(Prefab, CharacterController.Player.transform.position, Prefab.transform.rotation);
    }
}
