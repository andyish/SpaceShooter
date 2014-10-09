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

	private int scoreCounter = 0;
	private bool restart = false;
	private bool gameOver = false;

	void Start () {
		restartText.text = "";
		gameOverText.text = "";
		
		UpdateScore ();
		StartCoroutine (SpawnSideFighters ());
		StartCoroutine (SpawnTopDown ());
	}
	
	void Update () {
		if (restart) {
			if (Input.GetKeyDown (KeyCode.R)) {
				Application.LoadLevel (Application.loadedLevel);
			} else if(Input.GetKeyDown (KeyCode.Q)) {
				Application.LoadLevel ("MainMenu");
			}
		}
	}

	public void AddScore(int score) {
		scoreCounter += score;
		UpdateScore ();
	}
	
	
	IEnumerator SpawnTopDown ()
	{
		yield return new WaitForSeconds (2);
		
		for(int i = 0; i < 10; i++) {
			if(gameOver) {
				break;
			}
			
			Vector2 spawnPosition = new Vector2(Random.Range(-7, 7), 11);
			
			GameObject enemy =(GameObject) Instantiate(hazards[2], spawnPosition, Quaternion.identity);
			enemy.transform.Rotate(0, 0, 180);
			Mover mover = enemy.GetComponent<Mover>();
			mover.xVelocity = 0f;
			mover.yVelocity = -3f;
			
			yield return new WaitForSeconds (Random.Range(0.9f, 1.8f));
		}
		
		yield return new WaitForSeconds (3);
	}
		

	IEnumerator SpawnSideFighters ()
	{
		yield return new WaitForSeconds (4);

		float yPos = 5f;
		bool up = true;
		for(int i = 0; i < 50; i++) {
			if(gameOver) {
				break;
			}
		
			Vector2 spawnPosition = new Vector2(-9, yPos);
			
			if(up && yPos > 9) {
				up = false;
			} else if (!up && yPos < 3) {
				up = true;
			}
			
			if(up) 
				yPos += 0.75f;
			else
				yPos -= 0.75f;
				
			GameObject enemy =(GameObject) Instantiate(hazards[2], spawnPosition, Quaternion.identity);
			enemy.transform.Rotate(0, 0, 270);
			Mover mover = enemy.GetComponent<Mover>();
			mover.xVelocity = 4f;
			mover.yVelocity = 0f;
			
			yield return new WaitForSeconds (0.6f);
		}
		
		yield return new WaitForSeconds (3);
		
		//Complete
		Completed();
	}

	void UpdateScore() {
		scoreText.text = "Score: " + scoreCounter;
	}

	void spawnBoss () {
		Vector2 spawnPosition = new Vector2(Random.Range(-5, 5), 6);
		Instantiate (boss, spawnPosition, Quaternion.identity);
	}
	
	public void GameOver () {
		gameOverText.text = "Game Over!";
		restartText.text = "Press R to restart game";
		gameOver = true;
		restart = true;
	}
	
	void Completed () {
		if(!gameOver) {
			gameOverText.text = "Complete!";
			restartText.text = "Press R to play again or Q to quit";
			restart = true;
		}
	}
}
