using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUI : MonoBehaviour {

    public Image health;
    public Image spiritEnergy;
    public GameObject highlight;
    private CharacterController player;

	void Start () {
        player = FindObjectOfType<CharacterController>();
        player.Health.OnDamageTaken += UpdateHP;
	    player.Energy.OnValueChange += UpdateMP;
	    player.Energy.OnFullValue += Highlight;
	}
	
	void UpdateHP () {
        health.fillAmount = player.Health.HealthAsPercentage;
	}

    void UpdateMP()
    {
        spiritEnergy.fillAmount = player.Energy.EnergyAsPercentage * 0.82f;
    }

    void Highlight()
    {
        highlight.SetActive(!highlight.activeSelf);
    }
}
