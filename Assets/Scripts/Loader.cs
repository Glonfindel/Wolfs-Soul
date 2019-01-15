using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{

    IEnumerator Start()
    {
        yield return null;
        int slot = PlayerPrefs.GetInt("Slot");
        if (slot > 0)
        {
            foreach (var obj in PlayerPrefsX.GetStringArray("ITriggers" + slot))
            {
                var trigger = FindObjectsOfTypeAll<MonoBehaviour>().OfType<ITrigger>().FirstOrDefault(e => e.GameObject.name == obj);
                if (trigger != null)
                {
                    if (trigger.Parent != null)
                        trigger.Parent.OnTrigger(trigger.GameObject);

                    if (trigger is EnemyController)
                        Destroy(trigger.GameObject);
                }
            }
            CharacterController.Player.transform.position = PlayerPrefsX.GetVector3("Position" + slot);
            CharacterController.Player.transform.rotation = PlayerPrefsX.GetQuaternion("Rotation" + slot);
            CharacterController.Player.Health.CurrentHealth = PlayerPrefs.GetFloat("Health" + slot);
            CharacterController.Player.Energy.CurrentEnergy = PlayerPrefs.GetFloat("Energy" + slot);
        }
    }
    public static List<T> FindObjectsOfTypeAll<T>()
    {
        List<T> results = new List<T>();
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            var s = SceneManager.GetSceneAt(i);
            if (s.isLoaded)
            {
                var allGameObjects = s.GetRootGameObjects();
                for (int j = 0; j < allGameObjects.Length; j++)
                {
                    var go = allGameObjects[j];
                    results.AddRange(go.GetComponentsInChildren<T>(true));
                }
            }
        }
        return results;
    }
}
