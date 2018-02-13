using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class EnemyScript : MonoBehaviour {

	public GameObject enemyExplosion;
	public GameObject shipExplosion;

	public static int Score;
	public static bool isDead = false;
	private GameManagerScript GMS;
	private float speed;

	void Awake() {
		GMS = GameObject.Find ("GameManager").GetComponent<GameManagerScript> ();
	}

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		checkSpeed ();
		float new_z = transform.position.z - speed;
		transform.position = new Vector3 (transform.position.x, transform.position.y, new_z);
		if (transform.position.z < 0) {
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter(Collider other) 
	{
		if(other.CompareTag("Player")) 
		{
			isDead = true;
			var exp = Instantiate (enemyExplosion, transform.position + new Vector3(0, 1.3f, 0), transform.rotation);
			Destroy (exp, 1f);
			var shipExp = Instantiate (shipExplosion, transform.position, transform.rotation);
			Destroy (shipExp, 1f);
			Destroy (gameObject);
			other.gameObject.SetActive (false);
		}
		if(other.CompareTag("Bullet"))
		{
			Score += 5;

			Destroy (other.gameObject);
			var exp = Instantiate (enemyExplosion, transform.position + new Vector3(0, 1.3f, 0), transform.rotation);
			Destroy (exp, 1f);
			Destroy(gameObject);
		}
	}

	private void checkSpeed()
	{
		if (GMS.getStarsSpawned () == 0) {
			speed = 0.1f;
		} else if (GMS.getStarsSpawned () == 1) {
			speed = 0.15f;
		} else if (GMS.getStarsSpawned () == 2) {
			speed = 0.2f;
		} else if (GMS.getStarsSpawned () == 3) {
			speed = 0.25f;
		} else if (GMS.getStarsSpawned () == 4) {
			speed = 0.3f;
		} else
			speed = 0.35f;
	}
}
