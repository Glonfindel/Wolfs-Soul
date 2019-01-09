using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        WWW server = new WWW("http://szuflandia.pjwstk.edu.pl/~s14614/dbConnection/IncrementCounter.php");
        yield return server;
        counterText.text = server.text;
    }
}
