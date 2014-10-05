using UnityEngine;
using System.Collections;

public class GameLevelController : MonoBehaviour {
	
	public TextMesh restartText;
	public TextMesh scoreText;
	public TextMesh gameOverText;

	public GameObject[] hazards;
	public GameObject boss;
	public Vector2 spawnArea;

	public int waveWait;
	public int waveCount;

	private bool isPlaying = true;
	private int scoreCounter = 0;
	private bool restart = false;
	private bool gameOver = false;

	void Start () {
		restartText.text = "";
		gameOverText.text = "";
		
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
	}
	
	void Update () {
		if (restart)
		{
			if (Input.GetKeyDown (KeyCode.R))
			{
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}

	public void AddScore(int score) {
		scoreCounter += score;
		UpdateScore ();
	}

	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (2);

		for(;;) {
			if(gameOver) {
				restartText.text = "Press R to restart game.";
				restart = true;
				break;
			}
		
			GameObject hazard = hazards[Random.Range(0, hazards.Length)];
			Vector2 spawnPosition = new Vector2(0, 6);
			Instantiate (hazard, spawnPosition, Quaternion.identity);
			
			yield return new WaitForSeconds (waveWait);
		}

		spawnBoss();
	}

	void UpdateScore() {
		scoreText.text = "Score: " + scoreCounter;
	}

	void spawnBoss () {
		Vector2 spawnPosition = new Vector2(Random.Range(-spawnArea.x, spawnArea.y), 6);
		Instantiate (boss, spawnPosition, Quaternion.identity);
	}
	
	public void GameOver ()
	{
		gameOverText.text = "Game Over!";
		gameOver = true;
	}
}
