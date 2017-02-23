using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReticleFollow : MonoBehaviour {
	public GameObject yawRef;
	public GameObject pitchRef;
	public float ratio;
	public float depth;
	public GameObject crosshair;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		float deg2rad = Mathf.PI / 180.0f;
		float yaw = deg2rad * yawRef.transform.localEulerAngles.y;
		float pitch = deg2rad * pitchRef.transform.localEulerAngles.x;
		crosshair.transform.localPosition = new Vector3 (ratio*Mathf.Tan (yaw), -ratio*Mathf.Tan (pitch), depth);
	}
	void LateUpdate(){
		if (crosshair.transform.localPosition.x > 25.0f ||
			crosshair.transform.localPosition.x < -25.0f ||
			crosshair.transform.localPosition.y > 20.0f ||
			crosshair.transform.localPosition.y < -20.0f)
			crosshair.SetActive (false);
		else
			crosshair.SetActive (true);
	}
}
