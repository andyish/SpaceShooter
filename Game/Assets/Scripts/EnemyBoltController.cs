﻿using UnityEngine;
using System.Collections;

public class EnemyBoltController : MonoBehaviour {
	
	public GameObject impactEffect;
	
	void OnImpact()
	{
		// Create a quaternion with a random rotation in the z-axis.
		//Quaternion randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
		
		// Instantiate the explosion where the rocket is with the random rotation.
		//Instantiate(impactEffect, transform.position, randomRotation);
	}
	
	void OnTriggerEnter2D (Collider2D col) {
		// If it hits an enemy...
		if (col.tag == "Player") {
			col.gameObject.GetComponent<PlayerController> ().InflictDamage ();
			
			OnImpact();
			Destroy (gameObject);
			Debug.Log ("EnemyBoltController");
		}
	}
}
