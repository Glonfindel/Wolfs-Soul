using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour {

    public Image healthUI;
    public Health health;
	void Start ()
	{
        health.OnDamageTaken += UpdateHP;
	}
	
	void UpdateHP () {
        healthUI.fillAmount = health.HealthAsPercentage;
	}
}
