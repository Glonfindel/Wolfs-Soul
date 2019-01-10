using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GamesCounter : MonoBehaviour
{

    private Text counterText;

    private void Awake()
    {
        counterText = GetComponent<Text>();
    }

    private void OnEnable()
    {
        StartCoroutine(ShowCounter());
    }

    IEnumerator ShowCounter()
    {
        UnityWebRequest www = UnityWebRequest.Get("http://szuflandia.pjwstk.edu.pl/~s14614/dbConnection/IncrementCounter.php");
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
            counterText.text = "Server communication error.";
        }
        else
        {
            counterText.text = www.downloadHandler.text;
        }
    }
}
