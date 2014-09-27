using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour {
	
	public float rotationSpeedMin;
	public float rotationSpeedMax;

	void Start () {
		rigidbody2D.angularVelocity = Random.Range(rotationSpeedMin, rotationSpeedMax);
	}
}
