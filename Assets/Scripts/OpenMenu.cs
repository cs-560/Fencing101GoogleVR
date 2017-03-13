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
	public float hold_interval;
	// Use this for initialization
	void Start () {
		state = State.Main;
		t0 = 0.0f;
	}
	// Update is called once per frame
	void Update(){
		if (Input.GetMouseButtonDown (0)) {
			t0 = Time.time;
		}
		if(Input.GetMouseButtonUp (0)){
			if (!menus.activeInHierarchy && Time.time - t0 < hold_interval)
				click = true;
			else
				print ("This was a hold and not a click");
		}
	}
	void LateUpdate() {
		if (menus.activeInHierarchy)
			return;
		if (click) {
			menus.SetActive (true);
			//if (state == State.Watch) {
				pause.SetActive (true);
				main.SetActive (false);
				help.SetActive (false);
				state = State.Pause;
			//}
			click = false;
		}
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
		if (state == State.MainHelp) {
			main.SetActive (true);
			state = State.Main;
		} else {
			pause.SetActive (true);
			state = State.Pause;
		}
		help.SetActive (false);
	}
	public void quit(){
		Application.Quit ();
	}
}
