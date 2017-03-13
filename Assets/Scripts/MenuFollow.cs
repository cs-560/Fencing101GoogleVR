using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuFollow : MonoBehaviour {
	public float dead_zone;
	public float speed;
	public float maxSpeed;
	public GameObject toFollow;
	public GameObject menus;
	// Use this for initialization
	void Start () {
	}
	// Update is called once per frame
	void Update () {
		bool menuOpen = menus.activeInHierarchy;
		if (menuOpen) {
			return;
		}
		float pitch = toFollow.transform.eulerAngles.x;
		float roll = toFollow.transform.eulerAngles.z;
		float yaw = toFollow.transform.eulerAngles.y;
		if (pitch > 180.0f)
			pitch -= 360.0f;
		if (roll > 180.0f)
			roll -= 360.0f;
		if (Input.GetMouseButton(0)) {
			if (pitch > dead_zone)
				pitch -= dead_zone;
			else if (pitch < -dead_zone)
				pitch += dead_zone;
			else
				pitch = 0.0f;
			if (roll > dead_zone)
				roll -= dead_zone;
			else if (roll < -dead_zone)
				roll += dead_zone;
			else
				roll = 0.0f;
			pitch *= speed;
			if (pitch > maxSpeed)
				pitch = maxSpeed;
			else if (pitch < -maxSpeed)
				pitch = -maxSpeed;
			roll *= speed;
			if (roll > maxSpeed)
				roll = maxSpeed;
			else if (roll < -maxSpeed)
				roll = -maxSpeed;
			transform.Translate (-roll * Time.deltaTime, 0.0f, pitch * Time.deltaTime);
			if(transform.position.x > 5.0f)
				transform.Translate (5.0f - transform.position.x , 0.0f, 0.0f, Space.World);
			if(transform.position.x < -5.0f)
				transform.Translate (-5.0f - transform.position.x , 0.0f, 0.0f, Space.World);
			if(transform.position.z > 10.0f)
				transform.Translate (0.0f, 0.0f, 10.0f - transform.position.z , Space.World);
			if(transform.position.z < -10.0f)
				transform.Translate (0.0f, 0.0f, -10.0f - transform.position.z , Space.World);
			toFollow.transform.Translate (transform.position.x - toFollow.transform.position.x, 0.0f, 
				transform.position.z - toFollow.transform.position.z, Space.World);
		}
		transform.Rotate (0.0f, yaw - transform.eulerAngles.y, 0.0f);
	}
}
