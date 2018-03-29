using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGotYouInSights : MonoBehaviour {

	void OnTriggerStay(Collider other){
		if (other.CompareTag ("Player") == true) {
			this.transform.parent.GetComponent<AIController>().playerSeen = true;	
		}
	}
	void OnTriggerExit(Collider other){
		if (other.CompareTag ("Player") == true) {
			this.transform.parent.GetComponent<AIController>().playerSeen = false;	
		}
	}
}
