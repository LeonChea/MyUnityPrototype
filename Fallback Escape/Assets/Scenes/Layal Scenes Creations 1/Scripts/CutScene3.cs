﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CutScene3 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine ("Countdown");
		
	}
	
	private IEnumerator Countdown(){


		yield return new WaitForSeconds (5);
		SceneManager.LoadScene("Store");
	}
}
