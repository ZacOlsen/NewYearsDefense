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

	}

	public void Quit () {
		Application.Quit ();
	}
}
