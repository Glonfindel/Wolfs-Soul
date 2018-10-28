using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUI : MonoBehaviour {

    public Image health;
    public Image spiritEnergy;
    private CharacterController player;
	void Start () {
        player = FindObjectOfType<CharacterController>();
        player.Health.OnDamageTaken += UpdateHP;
	}
	
	// Update is called once per frame
	void UpdateHP () {
        health.fillAmount = player.Health.HealthAsPercentage;
	}
}
