using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public GameObject PausePanel;
    public GameObject SavePanel;
    public GameObject DeathPanel;
    public GameObject WinPanel;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (CharacterController.Player.Input.Pause && !DeathPanel.activeSelf && !WinPanel.activeSelf && !SavePanel.activeSelf)
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
        EventSystem.current.SetSelectedGameObject(null);
        PausePanel.SetActive(false);
        DeathPanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void Restart()
    {
        PlayerPrefs.SetInt("Slot", 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void ShowSaves()
    {
        SavePanel.SetActive(!SavePanel.activeSelf);
        if (SavePanel.activeSelf) EventSystem.current.SetSelectedGameObject(SavePanel.GetComponentInChildren<Selectable>().gameObject);
        else EventSystem.current.SetSelectedGameObject(PausePanel.GetComponentInChildren<Selectable>().gameObject);
    }
}
