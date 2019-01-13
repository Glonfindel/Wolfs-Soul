using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject LoadingScreen;
    
    public void StartNewGame(string sceneName)
    {
        PlayerPrefs.SetInt("Slot", 0);
        StartCoroutine(LoadAsynchronously(sceneName));
    }

    public IEnumerator LoadAsynchronously(string sceneName)
    {
        LoadingScreen.SetActive(true);
        yield return null;
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        Slider slider = LoadingScreen.GetComponentInChildren<Slider>();
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            slider.value = progress;
            yield return null;
        }
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
