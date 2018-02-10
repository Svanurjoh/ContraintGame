﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsScript : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.down * 100 * Time.deltaTime);
		float new_z = transform.position.z - 0.1f;
		transform.position = new Vector3 (transform.position.x, transform.position.y, new_z);
	}
}
