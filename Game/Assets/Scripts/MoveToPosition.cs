using UnityEngine;
using System.Collections;

public class MoveToPosition : MonoBehaviour {
	
	public Vector2 destination;
	public float speed;

	private bool reached;
	private float triggerBuffer;

	// Use this for initialization
	void Start () {
		triggerBuffer = 0.25f;
		reached = false;
		rigidbody2D.AddForce (destination * speed);
	}

	void Update() {
		Vector3 moveDirection = rigidbody2D.velocity; 
		if (moveDirection != Vector3.zero) {
			float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.back);
		}

		if (reached) {
			circularFlightPath();
			return;
		}

		Debug.Log (Vector2.Distance (transform.position, destination));
		if (Vector2.Distance (transform.position, destination) < triggerBuffer) {
			gameObject.AddComponent("EvasiveManeuver_Circular");
			reached = true;
		}
	}

	private void circularFlightPath() {
		transform.RotateAround (new Vector3 (1, 1, 0),
		                        new Vector3 (0, 0, 10),
	    	                    2);
	}
}

