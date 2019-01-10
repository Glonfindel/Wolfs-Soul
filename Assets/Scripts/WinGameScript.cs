using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WinGameScript : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterController>())
        {
            UIManager.Instance.WinPanel.SetActive(true);
            EventSystem.current.SetSelectedGameObject(UIManager.Instance.WinPanel.GetComponentInChildren<Selectable>().gameObject);
            Camera.main.transform.parent = null;
            other.gameObject.SetActive(false);
        }
    }
}
