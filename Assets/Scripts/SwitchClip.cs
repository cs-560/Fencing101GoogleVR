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
		changeSpeed (1.0f);
	}
	public void HandControl(int n){
		if (n == 4)
			animator.SetTrigger ("ParryRiposte");
		if (n == 3)
			animator.SetTrigger ("Guards");
		if (n ==2)
			animator.SetTrigger("AdvanceLunge");
		if (n == 1)
			animator.SetTrigger ("Lunge");
	}
	public void changeSpeed(float sp){
		animator.speed = sp;
	}
}
