using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject DeathPanel;

    private void Update()
    {
        if (CharacterController.Player.Input.Pause && !DeathPanel.activeSelf)
        {
            PausePanel.SetActive(!PausePanel.activeSelf);
            Time.timeScale = PausePanel.activeSelf ? 0 : 1;
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
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
    }
}
