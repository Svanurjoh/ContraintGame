using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidScript : MonoBehaviour 
{
	private float speed;
	private GameManagerScript GMS;
	public GameObject explosion;


	void Awake() {
		GMS = GameObject.Find ("GameManager").GetComponent<GameManagerScript> ();
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
		if(other.gameObject.tag == "Player") 
		{
			var exp = Instantiate (explosion, transform.position + new Vector3(0, 1.3f, 0), transform.rotation);
			Destroy (exp, 1f);
			other.gameObject.SetActive (false);
			Debug.Log ("tri");
			//Destroy (other.gameObject);
		}
		if (other.gameObject.tag == "Bullet") {
			Destroy (other.gameObject);
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
