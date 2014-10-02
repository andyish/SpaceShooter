using UnityEngine;
using System.Collections;

public class EvasiveManeuver_Circular : MonoBehaviour {

    public Boundry startingBounds;

	void Start () {

	}
	
	void FixedUpdate() {
		this.transform.RotateAround	(new Vector3(1, 1, 0),
		                             new Vector3(0, 0, 10),
		                             2);
	}
}
	