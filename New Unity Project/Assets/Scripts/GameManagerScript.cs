using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour 
{
	public GameObject astroidPrefab;
	public GameObject starPrefab;
	public GameObject enemyPrefab;
	public GameObject[] spawnPoints;
	private GameObject[] tempSpawns;

	private float spawnTimer = 0f;
	private int spawnCounter = 0;
	private int activeSpawns = 4;
	private int spawnCooldown = 3;

	private ArrayList points;
	private bool shouldSpawn;

	void Start () 
	{
		points = new ArrayList ();
		shouldSpawn = true;
	}

	void Update () 
	{
		tempSpawns = spawnPoints;
		if (Time.time > spawnTimer) {
			for (int i = 0; i < 10; i++) {
				int spawn = Random.Range (0, spawnPoints.Length);
				int spawn1 = Random.Range(0, spawnPoints.Length);

				if(!Physics.CheckSphere(spawnPoints [spawn].transform.position, 1)){
					GameObject e = Instantiate (enemyPrefab, spawnPoints [spawn].transform.position, enemyPrefab.transform.rotation) as GameObject;
				}
				if(!Physics.CheckSphere(spawnPoints [spawn1].transform.position, 1)){
					GameObject e = Instantiate (astroidPrefab, spawnPoints [spawn1].transform.position, astroidPrefab.transform.rotation) as GameObject;
				}
				//GameObject a = Instantiate (astroidPrefab, spawnPoints [spawn1].transform.position, astroidPrefab.transform.rotation) as GameObject;
			}
			if (spawnCounter == 2) {
				int starSpawn;
				do {
					starSpawn = Random.Range (0, spawnPoints.Length);
				} while(Physics.CheckSphere (spawnPoints [starSpawn].transform.position, 2));
				GameObject s = Instantiate (starPrefab, spawnPoints[starSpawn].transform.position, starPrefab.transform.rotation) as GameObject;
				spawnCounter = 0;
			}
				
			spawnTimer = Time.time + spawnCooldown;
			spawnCounter += 1;
			//points.Clear();

			/*GameObject e6 = Instantiate (enemyPrefab, spawnPoints[1].transform.position, enemyPrefab.transform.rotation) as GameObject;
			GameObject e2 = Instantiate (enemyPrefab, spawnPoints[2].transform.position, enemyPrefab.transform.rotation) as GameObject;
			GameObject e5 = Instantiate (enemyPrefab, spawnPoints[3].transform.position, enemyPrefab.transform.rotation) as GameObject;
			GameObject e3 = Instantiate (enemyPrefab, spawnPoints[4].transform.position, enemyPrefab.transform.rotation) as GameObject;
			GameObject e7 = Instantiate (enemyPrefab, spawnPoints[5].transform.position, enemyPrefab.transform.rotation) as GameObject;
			GameObject e9 = Instantiate (enemyPrefab, spawnPoints[24].transform.position, enemyPrefab.transform.rotation) as GameObject;*/
		}
	}
}
