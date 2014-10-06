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
	public Transform shotSpawn;
	public List<GameObject> shotList = new List<GameObject>();
	public TextMesh hullText;
	public int maxHull;
	public GameLevelController gameController;
	public GameObject explosion;
	
	private GameObject shot;
	private int currentHull;
	private float nextFire;
	private int weaponLevel;

	void Start() {
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("LevelController");
		gameController = gameControllerObject.GetComponent <GameLevelController> ();

		currentHull = maxHull;
		UpdateHull ();
		weaponLevel = 0;
		shot = shotList[weaponLevel];
	}

	void Update() {
		if (Input.GetKey (KeyCode.Space) && Time.time > nextFire) {
			nextFire = Time.time + fireRate;

			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
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

	public void InflictDamage() {
		currentHull--;
		UpdateHull ();

		if (currentHull < 1) {
			gameController.GameOver();
			rigidbody2D.velocity = new Vector2(0, 0);
			
			Instantiate(explosion, transform.position, Quaternion.identity);
			Destroy(this);
		}
	}
	
	public void WeaponUpgrade() {
		weaponLevel++;
		if(weaponLevel < shotList.Count) {
			shot = shotList[weaponLevel];
		}
	}
	
	void UpdateHull() {
		hullText.text = "Hull: " + currentHull;
	}
}
