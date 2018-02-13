using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManagerScript : MonoBehaviour 
{
	public GameObject astroidPrefab;
	public GameObject starPrefab;
	public GameObject enemyPrefab;
	public GameObject[] spawnPoints;
	public GameObject player;
	public GameObject planet;

	public TextMeshProUGUI scoreText;
	public TextMeshProUGUI dieText;
	public int starsCollected;
	private int starsSpawned = 0;

	private float spawnTimer = 0f;
	private int spawnCounter = 0;
	private int activeSpawns = 4;
	private float spawnCooldown = 3;
	private int maxSpawns = 5;

	void Start () 
	{
		
	}

	void Update () 
	{
		if (Time.time > spawnTimer) {
			if (planet.transform.position.z > 40) {
				for (int i = 0; i < maxSpawns; i++) {
					int spawn = Random.Range (0, spawnPoints.Length);
					int spawn1 = Random.Range(0, spawnPoints.Length);

					if(!Physics.CheckSphere(spawnPoints [spawn].transform.position, 1)){
						GameObject e = Instantiate (enemyPrefab, spawnPoints [spawn].transform.position, enemyPrefab.transform.rotation) as GameObject;
					}
					if(!Physics.CheckSphere(spawnPoints [spawn1].transform.position, 1)){
						GameObject e = Instantiate (astroidPrefab, spawnPoints [spawn1].transform.position, astroidPrefab.transform.rotation) as GameObject;
					}
				}
			}
				
			if (spawnCounter == 5) {
				int starSpawn;
				do {
					starSpawn = Random.Range (0, spawnPoints.Length);
				} while(Physics.CheckSphere (spawnPoints [starSpawn].transform.position, 2));
				GameObject s = Instantiate (starPrefab, spawnPoints[starSpawn].transform.position, starPrefab.transform.rotation) as GameObject;
				spawnCounter = 0;
				maxSpawns += 2;
				starsSpawned++;
				spawnCooldown -= 0.2f;
			}
				
			spawnTimer = Time.time + spawnCooldown;
			spawnCounter += 1;
		}

		checkForInput ();
			
		scoreText.SetText ("Score: " + EnemyScript.Score.ToString ());
		if (player.activeSelf == false) {
			dieText.SetText ("Game over! \n press escape to quit \n spacebar/r to restart");
		} else {
			dieText.SetText ("");
		}
		if (planet.transform.position.z <= 40) {
			player.SetActive (false);
			scoreText.SetText ("");
			dieText.SetText ("YOU WON!!!! \n Your score : " + EnemyScript.Score.ToString () + "\n\n press escape to quit \n spacebar/r to restart");
		}
			
	}

	void reset() {
		EnemyScript.Score = 0;
		player.SetActive (true);
		SceneManager.LoadScene ("Main");
	}

	public void starCollected()
	{
		starsCollected++;
	}

	public int getStarsCollected()
	{
		return starsCollected;
	}

	public int getStarsSpawned()
	{
		return starsSpawned;
	}

	public void checkForInput()
	{
		if (Input.GetKey (KeyCode.R)) {
			reset ();
		}
		if (Input.GetKey (KeyCode.Space)) {
			reset ();
		}
		if (Input.GetKey (KeyCode.Escape)) {
			Application.Quit ();
		}
	}
}
