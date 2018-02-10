using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidScript : MonoBehaviour {

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
			Debug.Log("Hit player");
			//Destroy (other.gameObject);
		}
	}
}
