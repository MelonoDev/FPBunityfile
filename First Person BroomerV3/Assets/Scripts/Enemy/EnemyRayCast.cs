using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRayCast : MonoBehaviour {


	private GameObject Player;
	private Transform TrPlayer;
	public float HowFar = 1000.0f;

	void Awake(){
		GameObject Player = GameObject.Find("RigidBodyFPSController");
		TrPlayer = Player.GetComponent<Transform> ();

	}

	void Update () {


		transform.LookAt (TrPlayer); 


	} 
	void FixedUpdate()
	{

		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		Debug.DrawRay(transform.position, fwd * HowFar, Color.red);
		RaycastHit hit;

		if (Physics.Raycast (transform.position, fwd, out hit, HowFar) && hit.transform.tag == "Player") {
			this.transform.parent.GetComponent<AIController> ().playerRaycast = true;
		} else {
			this.transform.parent.GetComponent<AIController> ().playerRaycast = false;
		}
		Debug.DrawRay(transform.position, fwd, Color.green);
	}
}
