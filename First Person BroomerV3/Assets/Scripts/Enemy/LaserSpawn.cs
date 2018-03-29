using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpawn : MonoBehaviour {

	public AIController aIController;
	private bool CheckShot = true;
	private int counter = 0;
	public int maxCount = 60;

	public GameObject laser;
	public AudioSource NoticeSound;
	private bool firstNotice;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (aIController.ShootThePlayer == true) {
			if (CheckShot == true) {
				counter += 1;

			}


		} 

/*
		if (firstNotice == true){
			if (NoticeSound.isPlaying == false && aIController.alive == true) {
				if ((aIController.playerSeen == false) || (aIController.playerRaycast == false)) {
					NoticeSound.Play ();
					print ("Hey");
					firstNotice = false;
				}
			}
		}
		if ((aIController.playerSeen == true) || (aIController.playerRaycast == true)){
			firstNotice = true;
		}
*/

		if (counter == maxCount && aIController.alive == true) {
			Instantiate (laser, this.transform.position, this.transform.rotation);
			counter = 0;
		}
	}
}
