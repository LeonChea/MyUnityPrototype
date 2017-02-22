﻿using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

	public Canvas quitMenu;
	public Button startText;
	public Button exitText;



	// Use this for initialization
	void Start () {
		quitMenu = quitMenu.GetComponent<Canvas> ();
		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();  
		quitMenu.enabled = false; // this enable the quit menu when the game start 

	}

	public void ExitPress(){
		quitMenu.enabled = true;
		startText.enabled = false;
		exitText.enabled = false;
	}
	public void NoPress(){
		quitMenu.enabled = false;
		startText.enabled = true;
		exitText.enabled = true;

	}

	public void StartLevel(){
		//Application.LoadLevel (1);
		SceneManager.LoadScene("Level1");



	}
	public void ExitGame(){
		Application.Quit ();
	}
	// Update is called once per frame
	//TLS looked at this code

}
