using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	public Transform target;
	public float m_speed;
	Camera followcharcter;

	// Use this for initialization
	void Start () {
		followcharcter = GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
		followcharcter.orthographicSize = (Screen.height / 100f);

		if (target) {
			transform.position = Vector3.Lerp (transform.position, target.position, m_speed) + new Vector3 (0, 0, -10);
		}
	}
}
