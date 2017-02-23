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
	// Use this for initialization
	void Start () {
		state = State.Main;
	}
	
	// Update is called once per frame
	void Update(){
		if (!menus.activeInHierarchy)
			state = State.Watch;
		if (help.activeInHierarchy){
			if (state == State.Main)
				state = State.MainHelp;
			else if(state == State.Pause)
				state = State.PauseHelp;
		}
	}
	void LateUpdate() {
		if (Input.GetMouseButtonUp (1)) {
			if (menus.activeInHierarchy){
				if (help.activeInHierarchy) {
					if (state == State.MainHelp) {
						main.SetActive (true);
						state = State.Main;
					} else {
						pause.SetActive (true);
						state = State.Pause;
					}
					help.SetActive (false);
				} else {
					menus.SetActive (false);
					state = State.Watch;
				}
			}
			else {
				menus.SetActive (true);
				if (state == State.Watch) {
					pause.SetActive (true);
					main.SetActive (false);
					help.SetActive (false);
					state = State.Pause;
				}
			}
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
