using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class Level3Script : MonoBehaviour {
	public Canvas Level3;

	public Button Exit; 

	// Use this for initialization
	void Start () {
		Level3 = Level3.GetComponent<Canvas> ();
		Exit = Exit.GetComponent<Button> ();
	}

	
	// Update is called once per frame
	public void ExitGame(){
		Application.Quit ();
	}
}
