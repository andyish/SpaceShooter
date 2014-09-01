using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public float velocity;

	void Start () {
		rigidbody2D.velocity = new Vector2(0, velocity);
	}
}
