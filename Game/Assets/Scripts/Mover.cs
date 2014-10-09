using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public float xVelocity;
	public float yVelocity;

	void Start () {
		rigidbody2D.velocity = new Vector2(xVelocity, yVelocity);
	}
}
