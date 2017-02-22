
using UnityEngine;

public class ControlPlayer : MonoBehaviour {

 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update()	{

        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 50.0f;
		var y = Input.GetAxis("Vertical") * Time.deltaTime * 50.0f;

		transform.Translate(x, 0, 0);
		transform.Translate(0, y, 0);
	}

}
