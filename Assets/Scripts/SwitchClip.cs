using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchClip:MonoBehaviour {
	public Animator animator;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	// Update is called once per frame
	void Update () {
	}
	public void SetActivate(int n){
		animator.SetInteger ("Clip", n);
		animator.SetTrigger ("switch");
	}
}
