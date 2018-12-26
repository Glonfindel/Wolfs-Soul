using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMotor : MonoBehaviour
{

    [SerializeField] private float speed = 3f;

	void Update ()
	{
        transform.position += transform.forward * speed * Time.deltaTime;
	}

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
