using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadTilt : MonoBehaviour {
	public float rotate_speed;
	public GameObject menus;
	public GameObject torso;
	public GameObject player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		bool menuOpen = menus.activeInHierarchy;
		float pitch = Input.GetAxis ("Mouse Y") * -rotate_speed;
		float yaw = 0;
		if(menuOpen){
			yaw = Input.GetAxis ("Mouse X") * rotate_speed;
			torso.transform.Rotate (0, yaw, 0);
			yaw = yaw / 2.0f;
			pitch = pitch / 2.0f;
		}
		else if(torso.transform.localEulerAngles.y != 0.0f){
			player.transform.Rotate (0.0f, torso.transform.localEulerAngles.y, 0.0f);
			torso.transform.Rotate (0.0f, -torso.transform.localEulerAngles.y, 0.0f);
		}
		transform.Rotate (pitch, 0.0f, 0.0f);
		if (transform.localEulerAngles.x < 290.0f && transform.localEulerAngles.x > 180.0f)
			transform.localEulerAngles = new Vector3 (290.0f, 0.0f, 0.0f);
		if (transform.localEulerAngles.x > 70.0f && transform.localEulerAngles.x <= 180.0f)
			transform.localEulerAngles = new Vector3 (70.0f, 0.0f, 0.0f);
	}
}
