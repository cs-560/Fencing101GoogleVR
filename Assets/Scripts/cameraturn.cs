using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraturn : MonoBehaviour {
	public float turn_rate;
	private float r0;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.LeftControl)) {
			float yaw = turn_rate * Input.GetAxis ("Mouse X");
			float pitch = -turn_rate * Input.GetAxis ("Mouse Y");
			transform.Rotate (pitch, yaw, -transform.rotation.eulerAngles.z);
		}
		if (Input.GetKey (KeyCode.LeftAlt)) {
			float roll = turn_rate * Input.GetAxis ("Mouse X");
			transform.Rotate (0, 0, roll);
		} else {
			float tilt = transform.eulerAngles.z;
			if (tilt > 180.0f)
				tilt -= 360.0f;
			transform.Rotate (0, 0, -tilt / 3.0f);
		}
	}
	void lateUpdate(){

	}
}
