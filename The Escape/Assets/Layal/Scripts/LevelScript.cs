using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelScript : MonoBehaviour {

	public Canvas Level1;
	public Button NextLevel; 
	public Button Exit; 

	// Use this for initialization
	void Start () {
		Level1 = Level1.GetComponent<Canvas> ();
		NextLevel = NextLevel.GetComponent<Button> ();  
		Exit = Exit.GetComponent<Button> ();
	}


	
	// Update is called once per frame
	public void update(){
		
		SceneManager.LoadScene("Level2");



	}

	public void ExitGame(){
		Application.Quit ();
	}




}
