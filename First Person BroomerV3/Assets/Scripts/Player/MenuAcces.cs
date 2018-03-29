using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;


public class MenuAcces : MonoBehaviour {

	public RigidbodyFirstPersonController PauseController;
	public MouseLook mouselook;
	public GameObject TheMenu; //The buttons from the menu: MenuParent


	private bool pauser = false;

	// Use this for initialization
	void Start () {
		GameObject TheMenu = GameObject.Find("MenuParent");
		PauseController.enabled = true;
		Time.timeScale = 1;
		Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("p")) {
			if (pauser == false) {
				Cursor.lockState = CursorLockMode.None;
				PauseController.enabled = false;
				Time.timeScale = 0;
				Cursor.visible = true;

			}
			if (pauser == true) {
				PauseController.enabled = true;
				Time.timeScale = 1;
				Cursor.visible = false;
			}
			TheMenu.SetActive (!pauser);
			pauser = !pauser;

		}
	}
}
