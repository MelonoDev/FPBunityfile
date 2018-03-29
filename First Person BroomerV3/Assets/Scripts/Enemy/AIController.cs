using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AIController : MonoBehaviour
{

	public Transform Player;
	public int MoveSpeed = 4;
	public int MaxDist = 10;
	public int MinDist = 5;
	public bool playerSeen = false;
	public bool alive = true;
	public Rigidbody rb;
	public int TerminalVelocity = 2;

	public float dynFriction = 0.3f;
	public float statFriction = 0.3f;
	public float Bounciness = 10.0f;
	public Collider coll;
	public AudioSource RoboBG;
	private bool isDead = true;

	public bool playerRaycast = false;

	public bool ShootThePlayer = true; //refers to wether to shoot in script Laserspawn

	//spotlight attached
	public GameObject searchLight;

	//Enemy has noticed you sound
	public AudioSource NoticePlayer;
	private bool audioBool = true;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		Player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	void Update()
	{
		if (alive == true) {
			if (playerSeen == true) {
				if (playerRaycast == true) {

					//playernoticed
					if (NoticePlayer.isPlaying == false && audioBool == true) {
						NoticePlayer.Play ();
						audioBool = false;
					}

					transform.LookAt (Player);
					ShootThePlayer = true;

					if (Vector3.Distance (transform.position, Player.position) >= MinDist) { 

						transform.position += transform.forward * MoveSpeed * Time.deltaTime;


						if (Vector3.Distance (transform.position, Player.position) <= MaxDist) {
							//you can do something here
						}
					}

				}
			} 
		}
		if ((playerSeen == false) || (playerRaycast == false) || (alive == false)){
			ShootThePlayer = false;
			audioBool = true;

		}

		 

		if (alive == false) {
			if (isDead == true) {
				rb.freezeRotation = false;

				coll = GetComponent<Collider> ();
				coll.material.dynamicFriction = dynFriction;
				coll.material.staticFriction = statFriction;
				coll.material.bounciness = Bounciness;
				RoboBG = GetComponent<AudioSource> ();
				RoboBG.mute = true;
				isDead = false;
				searchLight.SetActive (false);
			}
		}

	}



	void OnCollisionEnter(Collision collision){
		if (collision.relativeVelocity.magnitude > TerminalVelocity){
			alive = false;
		}
	}



}
