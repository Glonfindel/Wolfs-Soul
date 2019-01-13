using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveSystem : MonoBehaviour
{
    public int index = 1;
    private Text date;
    private Image image;

    private void OnEnable()
    {
        date = GetComponentInChildren<Text>();
        date.text = PlayerPrefs.GetString("Date" + index);
        image = GetComponentsInChildren<Image>().First(e => e.gameObject != gameObject);
        Texture2D tex = PlayerPrefsX.ReadTextureFromPlayerPrefs("Image" + index);
        if (tex)
        {
            image.enabled = true;
            image.sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
        }
        else
        {
            image.enabled = false;
        }
    }

    public void LoadGame()
    {
        string level = PlayerPrefs.GetString("Level" + index);
        if (!string.IsNullOrEmpty(level))
        {
            SceneManager.LoadScene(level);
            PlayerPrefs.SetInt("Slot", index);
        }
    }

    public void SaveGame()
    {
        PlayerPrefs.SetString("Date" + index, DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString());
        var currentRT = RenderTexture.active;
        Camera camera = Camera.main.transform.GetChild(0).GetComponent<Camera>();
        RenderTexture.active = camera.targetTexture;
        camera.Render();
        Texture2D image = new Texture2D(camera.targetTexture.width, camera.targetTexture.height);
        image.ReadPixels(new Rect(0, 0, camera.targetTexture.width, camera.targetTexture.height), 0, 0);
        image.Apply();
        RenderTexture.active = currentRT;
        PlayerPrefsX.WriteTextureToPlayerPrefs("Image" + index, image);
        PlayerPrefs.SetString("Level" + index, SceneManager.GetActiveScene().name);
        PlayerPrefsX.SetVector3("Position" + index, CharacterController.Player.transform.position);
        PlayerPrefsX.SetQuaternion("Rotation" + index, CharacterController.Player.transform.rotation);
        PlayerPrefs.SetFloat("Health" + index, CharacterController.Player.Health.CurrentHealth);
        PlayerPrefs.SetFloat("Energy" + index, CharacterController.Player.Energy.CurrentEnergy);
        PlayerPrefsX.SetStringArray("ITriggers" + index, Resources.FindObjectsOfTypeAll(typeof(MonoBehaviour)).OfType<ITrigger>().Where(e => e.Complete).Select(f => f.GameObject.name).ToArray());
    }
}
