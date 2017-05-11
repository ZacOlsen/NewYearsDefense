using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	[SerializeField] private string gameScene = null;

	public void StartGame () {
		SceneManager.LoadScene (gameScene);
	}

	public void Credits () {
		SceneManager.LoadScene ("Credits");
	}

	public void MainMenu () {
		SceneManager.LoadScene ("Start Menu");
	}

	public void Quit () {
		Application.Quit ();
	}
}
