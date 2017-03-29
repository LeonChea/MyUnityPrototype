using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class OpenningCards : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine ("Countdown");
		
	}
	
	private IEnumerator Countdown(){

		yield return new WaitForSeconds (30);
		SceneManager.LoadScene("House");
	}
}
