using UnityEngine;
using System.Collections;

public class EvasiveManeuver_Circular : MonoBehaviour {

	public int radius;
	public Vector2 startingPosition;
	private int angle;

	// Use this for initialization
	void Start () {
		//StartCoroutine(Evade());
	}
	
	IEnumerator Evade() {
		yield return new WaitForSeconds (1);
		while (true) {

			//Fly to starting point (left or right side of circle
			//When there start FixedUpdate  


			yield return new WaitForSeconds (0.20f);
		}
	}

	void FixedUpdate() {
		this.transform.RotateAround	(new Vector3(1, 1, 0),
		                             new Vector3(0, 0, 10),
		                             2);
	}
}
