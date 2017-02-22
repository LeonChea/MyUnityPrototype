using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	//initialized Rigidbody2D and Animator
	Rigidbody2D rbody;
	Animator animation;

	//Sets Values for Rigidbody2D and Animator
	void Start () {
		rbody = GetComponent<Rigidbody2D> ();
		animation = GetComponent<Animator> (); 
	}
		



	// Update is called once per frame
	void Update () {
		// Update values for character movement
		Vector2 movement_vector = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"))*5f;
		rbody.MovePosition (rbody.position + movement_vector * Time.deltaTime);

		// initilization of animation, calls character if moving or stationary
		if (movement_vector != Vector2.zero) {
			animation.SetBool ("iswalking", true);
			animation.SetFloat ("input_x", movement_vector.x);
			animation.SetFloat ("input_y", movement_vector.y);
		} else {
			animation.SetBool ("iswalking", false);
		}


	}
}
