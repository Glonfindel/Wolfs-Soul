using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpawnGameObject : MonoBehaviour
{

    public GameObject prefab;
    private CheckAllObjectives checkAllObjectives;
    private GameObject go;

    void Start()
    {
        checkAllObjectives = GetComponent<CheckAllObjectives>();
        checkAllObjectives.OnComplete += Spawn;
        go = Instantiate(prefab, transform.position + prefab.transform.position, prefab.transform.rotation);
        if (go.GetComponent<ITrigger>() != null && transform.parent&&transform.parent.GetComponent<CheckAllObjectives>())
        {
            transform.parent.GetComponent<CheckAllObjectives>().AddObjective(go.GetComponent<ITrigger>());
        }
        go.SetActive(false);
    }

    private void OnDestroy()
    {
        checkAllObjectives.OnComplete -= Spawn;
    }

    private void Spawn()
    {
        go.SetActive(true);
    }
}
