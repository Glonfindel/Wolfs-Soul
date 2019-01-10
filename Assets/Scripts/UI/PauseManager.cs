using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject DeathPanel;
    public GameObject WinPanel;

    private void Update()
    {
        if (CharacterController.Player.Input.Pause && !DeathPanel.activeSelf && !WinPanel.activeSelf)
        {
            PausePanel.SetActive(!PausePanel.activeSelf);
            if (PausePanel.activeSelf) EventSystem.current.SetSelectedGameObject(PausePanel.GetComponentInChildren<Selectable>().gameObject);
            else EventSystem.current.SetSelectedGameObject(null);
            Time.timeScale = PausePanel.activeSelf ? 0 : 1;
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1;
    }
    public void Resume()
    {
        PausePanel.SetActive(false);
        DeathPanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
}
