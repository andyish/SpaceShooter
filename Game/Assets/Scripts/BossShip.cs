using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BossShip : MonoBehaviour {
	
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
	public int burstFirst;
	
	void Start() {
		rigidbody2D.velocity = new Vector2(0f, -0.5f);

		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("LevelController");
		levelController = gameControllerObject.GetComponent <GameLevelController> ();
		
		StartCoroutine(Evade());
		StartCoroutine (Fire ());

		rigidbody2D.angularVelocity = 40f;
		speed = speed * 100;
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

	IEnumerator Fire () {	
		while (true) {
			yield return new WaitForSeconds (fireRate);
			foreach (Transform t in shotSpawn) {
				for (int i = 0; i < burstFirst; i++) {
						GameObject go = (GameObject)Instantiate (shot, t.position, t.rotation);
						go.rigidbody2D.AddForce ((t.localRotation * gameObject.transform.localRotation) * new Vector2 (0, speed));
						yield return new WaitForSeconds (0.1f);
				}
			}
		}
	}
}
