using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuActionScript : MonoBehaviour {



	public void Restart(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}

	public void QuitGame(){
		Application.Quit ();
	}

	public void ToTestScene(){
		SceneManager.LoadScene ("TestScene", LoadSceneMode.Single);
	}

	public void ToLevel01(){
		SceneManager.LoadScene ("Level01", LoadSceneMode.Single);
	}
}
