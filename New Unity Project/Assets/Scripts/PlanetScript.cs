using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetScript : MonoBehaviour {

	public GameObject player;

	void Awake() {
	}
	
	// Update is called once per frame
	void Update () {
		float new_z = transform.position.z;
		if (player.activeSelf == true) {
			new_z = transform.position.z - 0.08f;
		}
        if (transform.position.z > 40f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, new_z);
        }
    }
}
