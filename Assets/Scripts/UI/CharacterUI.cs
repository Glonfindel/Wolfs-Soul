using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUI : MonoBehaviour {

    public Image health;
    public Image spiritEnergy;
    public GameObject highlight;

	void Start () {
	    CharacterController.Player.Health.OnDamageTaken += UpdateHP;
	    CharacterController.Player.Health.OnHealed += UpdateHP;
	    CharacterController.Player.Energy.OnValueChange += UpdateMP;
	    CharacterController.Player.Energy.OnFullValue += Highlight;
	    CharacterController.Player.Energy.OnZeroValue += DisableHighlight;
    }

    private void OnDestroy()
    {
        CharacterController.Player.Health.OnDamageTaken -= UpdateHP;
        CharacterController.Player.Health.OnHealed -= UpdateHP;
        CharacterController.Player.Energy.OnValueChange -= UpdateMP;
        CharacterController.Player.Energy.OnFullValue -= Highlight;
        CharacterController.Player.Energy.OnZeroValue -= DisableHighlight;
    }

    void UpdateHP () {
        health.fillAmount = CharacterController.Player.Health.HealthAsPercentage;
	}

    void UpdateMP()
    {
        spiritEnergy.fillAmount = CharacterController.Player.Energy.EnergyAsPercentage * 0.82f;
    }

    void Highlight()
    {
        highlight.SetActive(true);
    }

    void DisableHighlight()
    {
        highlight.SetActive(false);
    }
}
