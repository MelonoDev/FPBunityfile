using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePushTrigger : MonoBehaviour {
	public float pushforce = 100;
	// Use this for initialization

	//sounds
	public AudioSource SweepSound;
	public float PitchMin = 1;	
	public float PitchMax = 2;
	private float pitchRange = 0;

	//counterforatt
	private int counter = 0;
	private int attackLength = 20;
	private int entireAttackLength = 60;
	private bool sweeping = false;
	private bool scrAlive;

	//for kill enemy
	public AIController aIController;
	public Animator BroomSweep;

	//for winning
	public GameObject WinCon;

	//For chicken
	public Rigidbody BirdRB;

	// Update is called once per frame
	void Update () {
		BroomSweep.SetBool ("SweepingBool", sweeping);
		if(counter == 0){
			if (Input.GetMouseButtonDown(0) == true) {
				sweeping = true;
				pitchRange = Random.Range (PitchMin, PitchMax);
				SweepSound.pitch = pitchRange;
				SweepSound.Play();

			}
		}
		if(sweeping == true) {
			counter += 1;
		}
		if (counter >= entireAttackLength) {
			counter = 0;
			sweeping = false;
		}
	}

	void OnTriggerStay (Collider other){
		if ((counter > 0) && (counter <= attackLength)) {
			if (other.GetComponent<Rigidbody> () != null) {
				if (other.CompareTag ("sw_object") == true) {
					other.GetComponent<Rigidbody> ().AddForce (transform.forward * pushforce);
					//scrAlive = other.GetComponent<AIController> (alive);
					if (other.GetComponent<AIController> () != null) {
						aIController = other.GetComponent<AIController> ();
						aIController.alive = false;
					}

					if (other.name == "Bird2") {
						WinCon.SetActive (true);
						Rigidbody BirdRB = other.GetComponent<Rigidbody>();
						BirdRB.isKinematic = false;
					}
				}
			}
		}
	}
}

