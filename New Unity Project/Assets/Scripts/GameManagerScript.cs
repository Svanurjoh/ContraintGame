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

	public TextMeshProUGUI scoreText;
	public TextMeshProUGUI dieText;

	private float spawnTimer = 0f;
	private int spawnCounter = 0;
	private int activeSpawns = 4;
	private int spawnCooldown = 3;
	private int maxSpawns = 5;

	void Start () 
	{
	}

	void Update () 
	{
		if (Time.time > spawnTimer) {
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

			if (spawnCounter % 5 == 0) {
				maxSpawns++;
			}

			if (spawnCounter == 10) {
				int starSpawn;
				do {
					starSpawn = Random.Range (0, spawnPoints.Length);
				} while(Physics.CheckSphere (spawnPoints [starSpawn].transform.position, 2));
				GameObject s = Instantiate (starPrefab, spawnPoints[starSpawn].transform.position, starPrefab.transform.rotation) as GameObject;
				spawnCounter = 0;
			}
				
			spawnTimer = Time.time + spawnCooldown;
			spawnCounter += 1;
		}


		scoreText.SetText ("Score: " + EnemyScript.Score.ToString ());
		if (EnemyScript.isDead) {
			
			dieText.SetText ("Game over! \n press escape to quit \n spacebar/r to restart");

			if (Input.GetKey (KeyCode.R)) {
				reset ();
			}
			if (Input.GetKey (KeyCode.Space)) {
				reset ();
			}
			if (Input.GetKey (KeyCode.Escape)) {
				Application.Quit ();
			}
		} else {
			dieText.SetText ("");
		}
	}

	void reset() {
		EnemyScript.Score = 0;
		EnemyScript.isDead = false;
		SceneManager.LoadScene ("Arnar_");
	}
}
