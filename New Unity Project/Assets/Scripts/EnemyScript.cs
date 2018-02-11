using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class EnemyScript : MonoBehaviour {

	public GameObject enemyExplosion;
	public static int Score;
	public static bool isDead = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		float new_z = transform.position.z - 0.1f;
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

			Debug.Log("Hit player");
			var exp = Instantiate (enemyExplosion, transform.position + new Vector3(0, 1.3f, 0), transform.rotation);
			Destroy (exp, 1f);
			Destroy (gameObject);
			Destroy (other.gameObject);
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
}
