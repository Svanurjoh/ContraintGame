using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsScript : MonoBehaviour {

	public GameObject pickupEffect;

	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.down * 100 * Time.deltaTime);
		float new_z = transform.position.z - 0.1f;
		transform.position = new Vector3 (transform.position.x, transform.position.y, new_z);
	}

	void OnTriggerEnter(Collider other) 
	{
		if(other.CompareTag("Player")) 
		{
			Debug.Log("Star hit player");
			Instantiate (pickupEffect, transform.position + new Vector3(0, 1.3f, 0), transform.rotation);
			Destroy (this.gameObject);
		}
	}
}
