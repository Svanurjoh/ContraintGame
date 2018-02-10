using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour 
{
	public GameObject astroidPrefab;
	public GameObject starPrefab;
	public GameObject enemyPrefab;

	private float spawnTimer = 0f;
	private int spawnCounter = 0;
	private int enemySpawnCount = 0;
	private int astroidSpawnCount = 0;

	private ArrayList points;
	private bool shouldSpawn;

	void Start () 
	{
		points = new ArrayList ();
		shouldSpawn = true;
	}

	void Update () 
	{
		if (Time.time > spawnTimer) {
			/*for (int i = 0; i < 3; i++) {
				int randomX = Random.Range (0, 3);
				int randomY = Random.Range (0, 3);
				for (int j = 0; j < points.Count; j+=2) {
					int x = points.IndexOf (j);
					int y = points.IndexOf (j + 1);
					Debug.Log (randomX + "  " + x + " " + points.Count);
					Debug.Log (randomY + "  " + y + " " + points.Count + " " + j);
					if (randomX - x <= 3 && randomX - x >= -3) {
						if (randomY - y <= 3 && randomY - y >= -3) {
							Debug.Log ("HERE");
							shouldSpawn = false;
						}
					}
					Debug.Log ("All checked");
				}
				if (shouldSpawn) {
					GameObject e6 = Instantiate (astroidPrefab, new Vector3 (randomX, randomY, 50), astroidPrefab.transform.rotation) as GameObject;
					points.Add (randomX);
					points.Add (randomY);
					Debug.Log (randomX + "," + randomY + " " + " DRAWN " + spawnCounter++);
					Debug.Log (points [0] + " " + points [1]);
				} else {
					shouldSpawn = true;
				}
			}*/
			spawnTimer = Time.time + 2.0f;
			spawnCounter += 1;
			//points.Clear();
			GameObject e1 = Instantiate (astroidPrefab, new Vector3 (0, 0, 50), astroidPrefab.transform.rotation) as GameObject;
			GameObject e6 = Instantiate (astroidPrefab, new Vector3 (3.5f, 3.5f, 50), astroidPrefab.transform.rotation) as GameObject;
			GameObject e2 = Instantiate (astroidPrefab, new Vector3 (7, 7, 50), astroidPrefab.transform.rotation) as GameObject;
			GameObject e5 = Instantiate (astroidPrefab, new Vector3 (10.5f, 10.5f, 50), astroidPrefab.transform.rotation) as GameObject;
			GameObject e3 = Instantiate (astroidPrefab, new Vector3 (14, 14, 50), astroidPrefab.transform.rotation) as GameObject;
			GameObject e7 = Instantiate (astroidPrefab, new Vector3 (17.5f, 17.5f, 50), astroidPrefab.transform.rotation) as GameObject;
			GameObject e9 = Instantiate (astroidPrefab, new Vector3 (0, 3.5f, 50), astroidPrefab.transform.rotation) as GameObject;
		}
	}
}
