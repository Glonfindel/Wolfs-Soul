using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public void StartNewGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        PlayerPrefs.SetInt("Slot", 0);
    }

    public void LoadGame(int index)
    {
        string level = PlayerPrefs.GetString("Save" + index);
        if (!string.IsNullOrEmpty(level))
            SceneManager.LoadScene(level);
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
