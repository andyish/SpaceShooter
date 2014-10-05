using UnityEngine;
using System.Collections;

public class WeaponPowerupController : MonoBehaviour {
	
	
	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "Player") {
			col.gameObject.GetComponent<PlayerController> ().WeaponUpgrade ();
			
			Destroy (gameObject);
			Debug.Log ("WeaponUpgradeController");
		}
	}
}
