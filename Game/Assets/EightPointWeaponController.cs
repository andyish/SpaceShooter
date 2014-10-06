using UnityEngine;
using System.Collections;

public class EightPointWeaponController : MonoBehaviour {
	
	public GameObject shot;
	public Transform shotSpawn;
	
	public float fireRate;
	public float delay;
	
	void Start ()
	{
		InvokeRepeating ("Fire", delay, fireRate);
	}
	
	void Fire ()
	{

		
		GameObject go = (GameObject) Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
		go.rigidbody2D.velocity = new Vector2(0, 1);
		gameObject.transform.Rotate(go.rigidbody2D.velocity, shotSpawn.rotation.z);

//		GameObject go = (GameObject)Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
//		go.rigidbody2D.AddForce ((gameObject.transform.localRotation * shotSpawn.transform.localRotation) * new Vector2 (0, 5));

//		shotSpawn.transform.Rotate (0, 0, 45);

	}
}
