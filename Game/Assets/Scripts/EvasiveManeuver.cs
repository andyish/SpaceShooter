using UnityEngine;
using System.Collections;

public class EvasiveManeuver : MonoBehaviour {
	
	public Boundry boundary;
	//public float tilt;
	public float dodge;
	public float smoothing;
	public Vector2 startWait;
	public Vector2 maneuverTime;
	public Vector2 maneuverWait;

	private float targetManeuver;
	
	void Start ()
	{
		StartCoroutine(Evade());
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
		
		//rigidbody2D.rotation = Quaternion.Euler (0, 0, rigidbody2D.velocity.x * -tilt);
	}
}
