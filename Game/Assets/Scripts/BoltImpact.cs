using UnityEngine;
using System.Collections;

public class BoltImpact : MonoBehaviour {

	public GameObject impactEffect;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag != "Boundary") {
			Instantiate(impactEffect, transform.position, transform.rotation);
			Destroy(other);
		}
	}
}
