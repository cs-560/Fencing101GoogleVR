using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenu : MonoBehaviour {
	public GameObject menus;
	public GameObject main;
	public GameObject pause;
	public GameObject help;
	public enum State {Watch, Main, MainHelp, Pause, PauseHelp};
	private State state;
	private bool click;
	private float t0;
	private float t_closed;
	public float hold_interval;
	public float menu_interval;
	public float dead_zone;
	public float speed;
	public float maxSpeed;
	public GameObject toFollow;
	public AudioClip a1;
	public AudioClip a2;
	public AudioClip a3;
	public AudioClip a4;
	public AudioSource audiosource;
	// Use this for initialization
	void Start () {
		state = State.MainHelp;
		t0 = 0.0f;
		audiosource = GetComponent<AudioSource> ();
	}
	// Update is called once per frame
	void Update(){
		if (Input.GetMouseButtonDown (0)) {
			t0 = Time.time;
		}
		if(Input.GetMouseButtonUp (0)){
			if (!menus.activeInHierarchy && Time.time - t0 < hold_interval)
				click = true;
			float dt = Time.time - t_closed;
			if (click && (dt > menu_interval)) {
			//	float ht = Time.time - t0;
			//	string output = string.Concat ("Time.time - t0 : ", ht.ToString ());
			//	print (output);
			//	output = string.Concat ("Time.time - t_closed : ", dt.ToString ());
			//	print (output);
				menus.SetActive (true);
				//if (state == State.Watch) {
				pause.SetActive (true);
				main.SetActive (false);
				help.SetActive (false);
				state = State.Pause;
				//}
			
			}
			click = false;
		}

		if (menus.activeInHierarchy)
			return;

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
	void LateUpdate() {

	}
	public void SetState(string to_set){
		if(to_set.Equals("Watch"))
			state = State.Watch;
		else if(to_set.Equals("Main"))
			state = State.Main;
		else if(to_set.Equals("MH"))
			state = State.MainHelp;
		else if(to_set.Equals("Pause"))
			state = State.Pause;
		else if(to_set.Equals("PH"))
			state = State.PauseHelp;
	}
	public void backFromHelp(){
		if (state == State.PauseHelp) {
			pause.SetActive (true);
			state = State.Pause;
		} else {
			main.SetActive (true);
			state = State.Main;
		}
		help.SetActive (false);
	}
	public void quit(){
		Application.Quit ();
	}
	public void ChangeVoice(int n){
		if (n == 1)
			audiosource.clip = a1;
		else if (n == 2)
			audiosource.clip = a2;
		else if (n == 3)
			audiosource.clip = a3;
		else if (n == 4)
			audiosource.clip = a4;
		audiosource.Play ();
		close_time ();
	}
	public void close_time(){
		t_closed = Time.time;
	}
}
