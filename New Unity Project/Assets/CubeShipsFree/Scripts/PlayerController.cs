﻿using UnityEngine;
using System.Collections;

// Heavily based on Unity Space Shooter tutorial
namespace CubeSpaceFree
{

    [System.Serializable]
    public class Boundary
    {
        public float xMin, xMax, yMin, yMax;
    }

    public class PlayerController : MonoBehaviour
    {
        public float speed;
        public float tilt;              // tilt factor
        public Boundary boundary;       // movememnt boundary

        public GameObject shot;         // bullet prefab
        public Transform shotSpawn;     // the turret (bullet spawn location)
        public Rigidbody myRigidbody;   // reference to rigitbody
		private float nextFire = 0;
		private float timeSinceShotFired = 0;
        public float fireRate = 1;

        public float smoothing = 5;     // this value is used for smoothing ovement
        private Vector3 smoothDirection;// used to smooth out mouse and touch control
		private bool isSButton;
		private GameManagerScript GMS;

		void Awake() {
			GMS = GameObject.Find ("GameManager").GetComponent<GameManagerScript> ();
		}

        void Start()
        {
            myRigidbody = GetComponent<Rigidbody>();
			isSButton = true;
        }

        void FixedUpdate()
        {
            // keyboard
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            // if keyboard direction key is pressed
			if (moveHorizontal != 0 || moveVertical != 0)
            {
				if (GMS.getStarsCollected() % 2 == 0) {
					myRigidbody.velocity = new Vector3 (moveHorizontal, moveVertical, 0.0f) * speed;
				} else {
					myRigidbody.velocity = new Vector3(moveVertical, moveHorizontal, 0.0f) * speed;
				}
            }
			transform.position = new Vector3 (
				Mathf.Clamp (transform.position.x, boundary.xMin, boundary.xMax),
				Mathf.Clamp (transform.position.y, boundary.yMin, boundary.yMax),
				0.0f
			);
        }

        void Update()
        {
			checkHowShoots ();
			if (isSButton) {
				fireS ();
			}
			if (!isSButton) {
				fireK ();
			}
        }

		private void fireS()
		{
			if (Input.GetButton ("Fire1") && Time.time > nextFire) 
			{
				incrementScore ();
				nextFire = Time.time + fireRate;
				var bullet = Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
				GetComponent<AudioSource> ().Play ();
				Destroy (bullet, 1.2f);
			}
		}

		private void fireK()
		{
			if (Input.GetButton ("Fire2") && Time.time > nextFire) 
			{
				incrementScore ();
				nextFire = Time.time + fireRate;
				var bullet = Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
				GetComponent<AudioSource> ().Play ();
				Destroy (bullet, 1.2f);
			}
		}

		private void checkHowShoots()
		{
			if (GMS.getStarsCollected () % 2 == 0) {
				isSButton = true;
			}
			if (GMS.getStarsCollected () % 2 != 0) {
				isSButton = false;
			}
		}

		private void incrementScore()
		{
			if (EnemyScript.Score > 0) {
				EnemyScript.Score -= 1;
			}
		}
    }
}
