using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour 
{
	public GameObject astroidPrefab;
	public GameObject starPrefab;
	public GameObject enemyPrefab;

	private float spawnTimer = 2.0f;

	void Start () 
	{
		
	}

	void Update () 
	{
		if (Time.time > spawnTimer) {
			GameObject e = Instantiate(enemyPrefab, new Vector3(Random.Range(0, 14), Random.Range(0, 14),50), enemyPrefab.transform.rotation) as GameObject;
			GameObject e1 = Instantiate(enemyPrefab, new Vector3(Random.Range(0, 14), Random.Range(0, 14),50), enemyPrefab.transform.rotation) as GameObject;
			GameObject e2 = Instantiate(enemyPrefab, new Vector3(Random.Range(0, 14), Random.Range(0, 14),50), enemyPrefab.transform.rotation) as GameObject;
			GameObject e3 = Instantiate(enemyPrefab, new Vector3(Random.Range(0, 14), Random.Range(0, 14),50), enemyPrefab.transform.rotation) as GameObject;

			GameObject e8 = Instantiate(astroidPrefab, new Vector3(Random.Range(0, 14), Random.Range(0, 14),50), astroidPrefab.transform.rotation) as GameObject;
			GameObject e7 = Instantiate(astroidPrefab, new Vector3(Random.Range(0, 14), Random.Range(0, 14),50), astroidPrefab.transform.rotation) as GameObject;
			GameObject e6 = Instantiate(astroidPrefab, new Vector3(Random.Range(0, 14), Random.Range(0, 14),50), astroidPrefab.transform.rotation) as GameObject;
			GameObject e5 = Instantiate(astroidPrefab, new Vector3(Random.Range(0, 14), Random.Range(0, 14),50), astroidPrefab.transform.rotation) as GameObject;

			GameObject star = Instantiate(starPrefab, new Vector3(Random.Range(0, 14), Random.Range(0, 14),50), starPrefab.transform.rotation) as GameObject;

			spawnTimer = Time.time + 2.0f;
		}
	}
}
