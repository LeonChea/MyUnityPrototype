using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour {

	public Transform warpTarget;

	//On trigger event of when charcater 2D collider meets another collider(Exit event) on map
	//Move character to another prefab(Target location)
	void OnTriggerEnter2D(Collider2D other) {
		other.gameObject.transform.position = warpTarget.position;
		Camera.main.transform.position = warpTarget.position;
	}
}
