using UnityEngine;
using System.Collections;

public class EnemyShip : MonoBehaviour {

	public float speed;
	
	void OnTriggerEnter(Collider other) {
		Debug.Log ("EnemyShip OnTriggerEnter");
	}
}
