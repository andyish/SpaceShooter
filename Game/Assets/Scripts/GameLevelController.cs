﻿using UnityEngine;
using System.Collections;

public class GameLevelController : MonoBehaviour {
	
	public TextMesh scoreText;

	public GameObject[] hazards;
	public GameObject boss;
	public Vector2 spawnArea;

	public float spawnWait;
	public int spawnCount;

	public int waveWait;
	public int waveCount;

	private bool isPlaying = true;
	private int scoreCounter;

	void Start () {
		scoreCounter = 0;
		StartCoroutine (SpawnWaves ());
		UpdateScore ();
	}
	
	void Update () {
	
	}

	public void AddScore(int score) {
		scoreCounter += score;
		UpdateScore ();
	}

	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (2);

		for(int wave = 0; wave < waveCount; wave++) {
			for(int i = 0; i < spawnCount; i++) {
				GameObject hazard = hazards[Random.Range(0, hazards.Length)];
				Vector2 spawnPosition = new Vector2(Random.Range(-spawnArea.x, spawnArea.y), 6);
				Instantiate (hazard, spawnPosition, Quaternion.identity);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
		}
		yield return new WaitForSeconds (waveWait);

		spawnBoss();
	}

	void UpdateScore() {
		scoreText.text = "Score: " + scoreCounter;
	}

	void spawnBoss () {
		Vector2 spawnPosition = new Vector2(Random.Range(-spawnArea.x, spawnArea.y), 6);
		Instantiate (boss, spawnPosition, Quaternion.identity);
	}
}
