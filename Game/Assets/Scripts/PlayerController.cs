using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[System.Serializable]
public class Boundry {
	public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour {

	public int speed;
	public Boundry bounds;
	public float fireRate;
	public GameObject shot;
	public List<Transform> shotSpawn = new List<Transform>();

	private float nextFire;

	void Update() {
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;

			foreach(Transform t in shotSpawn)
				Instantiate(shot, t.position, t.rotation);
		}
	}

	void FixedUpdate() {
		float hoz = Input.GetAxis ("Horizontal");
		float ver = Input.GetAxis ("Vertical");

		Vector2 heading = new Vector3 (hoz, ver);
		rigidbody2D.velocity = heading * speed;

		rigidbody2D.position = new Vector2
		(
			Mathf.Clamp (rigidbody2D.position.x, bounds.xMin, bounds.xMax),
			Mathf.Clamp (rigidbody2D.position.y, bounds.yMin, bounds.yMax)
		);
	}
}
