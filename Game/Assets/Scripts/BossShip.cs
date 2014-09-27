using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BossShip : MonoBehaviour {
	
	public int health;
	public GameObject explosion;
	private GameLevelController levelController;

	
	public Boundry boundary;
	//public float tilt;
	public float dodge;
	public float smoothing;
	public Vector2 startWait;
	public Vector2 maneuverTime;
	public Vector2 maneuverWait;
	
	private float targetManeuver;

	public GameObject shot;
	public List<Transform> shotSpawn = new List<Transform>();
	public float fireRate;
	public float delay;
	public float speed;
	
	void Start() {
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("LevelController");
		levelController = gameControllerObject.GetComponent <GameLevelController> ();
		
		StartCoroutine(Evade());
		InvokeRepeating ("Fire", delay, fireRate);

		rigidbody2D.angularVelocity = 30f;
	}

	void OnTriggerEnter2D(Collider2D other) {
		health -= 1;
		levelController.AddScore (1);
		
		if (health < 1) {
			Destroy(gameObject);
			Instantiate(explosion, transform.position, transform.rotation);
			levelController.AddScore(500);
		}
	}
	
	IEnumerator Evade ()
	{
		yield return new WaitForSeconds (Random.Range (startWait.x, startWait.y));
		while (true)
		{
			targetManeuver = Random.Range (1, dodge) * -Mathf.Sign (transform.position.x);
			yield return new WaitForSeconds (Random.Range (maneuverTime.x, maneuverTime.y));
			targetManeuver = 0;
			yield return new WaitForSeconds (Random.Range (maneuverWait.x, maneuverWait.y));
		}
	}
	
	void FixedUpdate ()
	{
		float newManeuver = Mathf.MoveTowards (rigidbody2D.velocity.x, targetManeuver, smoothing * Time.deltaTime);
		rigidbody2D.velocity = new Vector2 (newManeuver, rigidbody2D.velocity.y);
		rigidbody2D.position = new Vector2
			(
				Mathf.Clamp(rigidbody2D.position.x, boundary.xMin, boundary.xMax), 
				Mathf.Clamp(rigidbody2D.position.y, boundary.yMin, boundary.yMax)
				);

	}

	void Fire () {		
		foreach (Transform t in shotSpawn) {
			GameObject go = (GameObject) Instantiate (shot, t.position, t.rotation);
			go.rigidbody2D.velocity = new Vector2(0, 1);
			Rotate(go.rigidbody2D.velocity, t.rotation.z);
		}

	}

	Vector2 Rotate(Vector2 v, float degrees) {
		float sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
		float cos = Mathf.Cos(degrees * Mathf.Deg2Rad);
		
		float tx = v.x;
		float ty = v.y;
		v.x = (cos * tx) - (sin * ty);
		v.y = (sin * tx) + (cos * ty);
		return v;
	}
}
