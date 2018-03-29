using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
//using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour {

	private int OwnLife = 12;
	private int GetHurt = 4;
	public bool GetHit = false;
	public bool DeadPlayer = false;
	public RigidbodyFirstPersonController controller;
	public AudioSource HurtSound;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GetHit) {
			GetHit = !GetHit;
			OwnLife -= GetHurt;
			HurtSound.Play ();
		}

		if (OwnLife <= 0) {
			DeadPlayer = true;
		}

		if (DeadPlayer) {
			controller.enabled = false;
			//SceneManager.LoadScene(SceneManager.GetActiveScene().name);

		}
	}
}
