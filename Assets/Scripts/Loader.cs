using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

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
                var trigger = Resources.FindObjectsOfTypeAll(typeof(MonoBehaviour)).OfType<ITrigger>().FirstOrDefault(e => e.GameObject.name == obj);
                if (trigger != null)
                {
                    if (EditorUtility.IsPersistent(trigger.GameObject))
                        continue;
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
}
