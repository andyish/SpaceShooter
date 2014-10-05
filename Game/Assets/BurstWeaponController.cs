using UnityEngine;
using System.Collections;

public class BurstWeaponController : MonoBehaviour {
	
	public GameObject shot;
	public Transform shotSpawn;
	
	public float fireRate;
	public float delay;
	public int burstCount;
	
	void Start ()
	{
		StartCoroutine(Fire() );
		InvokeRepeating ("Fire", delay, fireRate);
	}
	
	IEnumerator Fire ()
	{
		yield return new WaitForSeconds (delay);
		
		for(int i = 0; i < burstCount; i++) {
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			yield return new WaitForSeconds (fireRate);
		}
	}
}
