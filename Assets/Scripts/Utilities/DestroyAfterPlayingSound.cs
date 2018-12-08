using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterPlayingSound : MonoBehaviour
{
    void Start()
    {
        try
        {
            Destroy(gameObject, GetComponent<AudioSource>().clip.length);
        }
        catch
        {
            Debug.Log("No audiosource on this object");
        }

    }
}
