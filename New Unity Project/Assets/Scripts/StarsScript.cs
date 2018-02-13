using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsScript : MonoBehaviour {

	public GameObject pickupEffect;
	public GameObject GM;
	private float speed;
	private GameManagerScript GMS;

	void Awake() {
		GMS = GameObject.Find ("GameManager").GetComponent<GameManagerScript> ();
	}
	void Update () {
		checkSpeed ();
		transform.Rotate (Vector3.down * 100 * Time.deltaTime);
		float new_z = transform.position.z - speed;
		transform.position = new Vector3 (transform.position.x, transform.position.y, new_z);
	}

	void OnTriggerEnter(Collider other) 
	{
		if(other.CompareTag("Player")) 
		{
			EnemyScript.Score += 50;
			Debug.Log("Star hit player");
			Instantiate (pickupEffect, transform.position + new Vector3(0, 1.3f, 0), transform.rotation);
			GMS.starCollected ();
			Destroy (this.gameObject);
		}
	}

	private void checkSpeed()
	{
		if (GMS.getStarsCollected () == 0) {
			speed = 0.1f;
		} else if (GMS.getStarsCollected () == 1) {
			speed = 0.15f;
		} else if (GMS.getStarsCollected () == 2) {
			speed = 0.2f;
		} else if (GMS.getStarsCollected () == 3) {
			speed = 0.25f;
		} else
			speed = 0.3f;
	}
}
