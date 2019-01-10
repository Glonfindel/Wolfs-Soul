using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGameScript : MonoBehaviour
{

    private PauseManager uiManager;

	void Start ()
	{
	    uiManager = FindObjectOfType<PauseManager>();
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterController>())
        {
            uiManager.WinPanel.SetActive(true);
            Camera.main.transform.parent = null;
            other.gameObject.SetActive(false);
        }
    }
}
