using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float new_z = transform.position.z - 0.1f;
        if (transform.position.z > 40f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, new_z);
        }
    }
}
