using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlScript : MonoBehaviour {
	public float speed;
	public float rotation_speed;
	public GameObject menus;
	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.F))
		if(Cursor.lockState == CursorLockMode.None)
			Cursor.lockState = CursorLockMode.Locked;
		else
			Cursor.lockState = CursorLockMode.None;
		bool menuOpen = menus.activeInHierarchy;
		if (menuOpen) {
			return;
		} 
		float walk = Input.GetAxis ("Vertical") * speed;
		float strafe = Input.GetAxis ("Horizontal") * speed;
		float turn = Input.GetAxis ("Mouse X") * rotation_speed;
		transform.Translate (strafe, 0, walk); 
		transform.Rotate (0, turn, 0);
	}
}
