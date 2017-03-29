using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	//Variable initialized
	public Transform target;
	public float m_speed;
	Camera followcharcter;

	//Initialization of Camera Value
	void Start () {
		followcharcter = GetComponent<Camera> ();
	}

	// Update is called once per frame of camera position
	void Update () {
		followcharcter.orthographicSize = (Screen.height / 100f);

		if (target) {
			transform.position = Vector3.Lerp (transform.position, target.position, m_speed) + new Vector3 (0, 0, -10);
		}
	}
}
