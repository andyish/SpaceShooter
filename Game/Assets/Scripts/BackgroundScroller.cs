using UnityEngine;
using System.Collections;

public class BackgroundScroller : MonoBehaviour {
	
	public float tileSizeY;
	public float scrollSpeed;
	private Vector3 startPosition;

	void Start () {
		startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		float newPosition = Mathf.Repeat (Time.time * scrollSpeed, tileSizeY);
		transform.position = startPosition + Vector3.down * newPosition;
	}
}
