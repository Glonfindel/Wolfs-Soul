﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void Disappear(GameObject go)
    {
        go.GetComponent<Animator>().Play("Disappear");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
