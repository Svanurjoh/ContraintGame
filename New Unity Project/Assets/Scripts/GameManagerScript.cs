using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour 
{
	public GameObject astroidPrefab;
	public GameObject starPrefab;
	public GameObject enemyPrefab;

	void Start () 
	{
		GameObject fireball = Instantiate(astroidPrefab, new Vector3(3,3,50), astroidPrefab.transform.rotation) as GameObject;
		GameObject astroid = Instantiate(starPrefab, new Vector3(6,0,50), starPrefab.transform.rotation) as GameObject;
		GameObject astroid1 = Instantiate(enemyPrefab, new Vector3(9,6,50), enemyPrefab.transform.rotation) as GameObject;
	}

	void Update () 
	{
		
	}
}
