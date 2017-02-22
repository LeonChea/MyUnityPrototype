
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class ColliderScript : MonoBehaviour {

	// Use this for initialization


	void OnCollisionEnter2D (Collision2D col){

		Debug.Log (this.gameObject.name + " collided with " + col.gameObject.name);
	}

}