using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	//public GameObject explosion;

	void OnTriggerEnter2D(Collider2D other) {

		if (tag == "Bolt" || other.tag == "Boundry" || other.tag == "EnemyBolt") {
			Destroy (gameObject);
			Debug.Log ("DestroyByContact");
		}
	}
}
