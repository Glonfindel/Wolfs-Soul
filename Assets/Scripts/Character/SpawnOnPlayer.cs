using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnPlayer : CombatComponent
{
    public GameObject[] Prefabs;
    private bool initialized;

    protected void OnEnable()
    {
        if (!initialized)
        {
            initialized = true;
            return;
        }

        int random = Random.Range(0, Prefabs.Length);
        Instantiate(Prefabs[random], CharacterController.Player.transform.position, Prefabs[random].transform.rotation);
    }
}
