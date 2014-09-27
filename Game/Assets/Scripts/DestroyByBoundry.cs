using UnityEngine;
using System.Collections;

public class DestroyByBoundry : MonoBehaviour {

	void OnTriggerExit2D(Collider2D other) 
	{
		Debug.Log ("OnTriggerExit2D");
		Destroy (other.gameObject);
	}
}
