using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroomHitboxFollowPlayer : MonoBehaviour {



	public Transform Character; // Target Object to follow
	public float speed=0.5F; // Enemy speed
	private Vector3 directionOfCharacter;
	private Vector3 positionInFront;
	public GameObject mainCamera;

	void Start() {
		mainCamera = GameObject.FindWithTag("MainCamera");

	}

	void Update () {
		positionInFront = mainCamera.transform.position;
		directionOfCharacter = (positionInFront + new Vector3 (0, 0, 0));
		directionOfCharacter = directionOfCharacter.normalized;    // Get Direction to Move Towards
		transform.Translate (directionOfCharacter * speed, Space.World);
	}
}

