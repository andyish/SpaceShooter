using UnityEngine;
using System.Collections;

public class DestroyByBoundry : MonoBehaviour {

	void OnTriggerExit2D(Collider2D other) 
	{
		if (other.tag != "Untagged") {
			Destroy (other.gameObject);
			Debug.Log ("DestroyByBoundry: " + other.tag);
		}

	}
}
