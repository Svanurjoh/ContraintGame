﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

	public void startGame() {
		SceneManager.LoadScene ("Main");
	}

	public void quitGame() {
		Debug.Log ("Quit");
		Application.Quit ();
	}
}