using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour {

	public float moveSpeed = 55.0f;
	private PlayerLife playerLife;

	void Start(){
		playerLife = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerLife> (); //Thanks aan de lesassistent
	}

	void FixedUpdate(){
		transform.position += transform.forward * moveSpeed * Time.deltaTime;
	
	}

	void OnCollisionEnter (Collision collision){

		if (collision.gameObject.CompareTag ("Player")) {
			//Bool van andere script true maken
			playerLife.GetHit = true;
		}
		Destroy(gameObject);
	}
}
