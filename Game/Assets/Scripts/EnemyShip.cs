using UnityEngine;
using System.Collections;

public class EnemyShip : MonoBehaviour {

	public int health;
	public GameObject explosion;
	private GameLevelController levelController;

	void Start() {
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("LevelController");
		levelController = gameControllerObject.GetComponent <GameLevelController> ();
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		health -= 1;
		levelController.AddScore (1);

		if (health < 1) {
			Destroy(gameObject);
			Instantiate(explosion, transform.position, transform.rotation);
			levelController.AddScore(5);
		}
	}
}
