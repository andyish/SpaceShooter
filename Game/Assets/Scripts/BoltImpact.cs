using UnityEngine;
using System.Collections;

public class BoltImpact : MonoBehaviour {

	public GameObject impactEffect;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag != "Boundary" || other.tag != "Player") {
			//Instantiate(impactEffect, other.transform.position, other.transform.rotation);
			Destroy(other.gameObject);
		}
	}
}
