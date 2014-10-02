using UnityEngine;
using System.Collections;

public class EvasiveManeuver : MonoBehaviour {
	
	public Boundry boundry;
	
	void Start ()
    {
        float x = Random.Range(boundry.xMin, boundry.xMax);
        float y = Random.Range(boundry.yMin, boundry.yMax);
        transform.position = new Vector3(x, y, 0);
	}
}
