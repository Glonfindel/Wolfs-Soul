using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transparency : MonoBehaviour
{
    private int layerMask = 1 << 9;
    private List<Transform> hiddenObject;

    public GameObject player;
    void Start()
    {
        hiddenObject = new List<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.transform.position - transform.position;

        RaycastHit[] hits = Physics.RaycastAll(transform.position, direction, Mathf.Infinity, layerMask);
        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            Transform currentHit = hit.transform;

            if (!hiddenObject.Contains(currentHit))
            {
                hiddenObject.Add(currentHit);
                Renderer[] renderers = hit.transform.GetComponentsInChildren<Renderer>();
                foreach (Renderer rend in renderers)
                {
                    if (rend)
                    {
                        Color tempColor = rend.material.color;
                        rend.material.SetFloat("Transparency",0.5f);
                    }
                }
            }
        }
        for (int i = 0; i < hiddenObject.Count; i++)
        {

            bool isHit = false;
            for (int j = 0; j < hits.Length; j++)
            {
                if (hiddenObject[i] == hits[j].transform)
                {
                    isHit = true;
                    break;
                }
            }

            if (!isHit)
            {
                Renderer[] renderers = hiddenObject[i].transform.GetComponentsInChildren<Renderer>(); 
                foreach (Renderer rend in renderers)
                {
                    if (rend)
                    {
                        Color tempColor = rend.material.color;
                        rend.material.SetFloat("Transparency", 0f);
                    }
                }
                hiddenObject.RemoveAt(i);
            }
        }
    }
}
