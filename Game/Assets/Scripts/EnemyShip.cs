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

	public void InflictDamage() {
		health--;

		if (health < 1) {
			Destroy(gameObject);
			Instantiate(explosion, transform.position, transform.rotation);
			levelController.AddScore(5);
		}
	}
}
