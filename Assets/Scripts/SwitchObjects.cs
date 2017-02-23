using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchObjects : MonoBehaviour {
	public GameObject go1;
	public GameObject go2;
	public GameObject go3;
	public GameObject go4;
	private int nActive;
	// Use this for initialization
	void Start () {
		go1.SetActive (false);
		go2.SetActive (false);
		go3.SetActive (false);
		go4.SetActive (false);
		nActive = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (nActive == 1) {
			go1.SetActive (true);
			go2.SetActive (false);
			go3.SetActive (false);
			go4.SetActive (false);
		} 
		else if (nActive == 2) {
			go2.SetActive (true);
			go1.SetActive (false);
			go3.SetActive (false);
			go4.SetActive (false);
		}
		else if (nActive == 3) {
			go3.SetActive (true);
			go2.SetActive (false);
			go1.SetActive (false);
			go4.SetActive (false);
		}
		else if (nActive == 4) {
			go4.SetActive (true);
			go2.SetActive (false);
			go3.SetActive (false);
			go1.SetActive (false);
		}
	}
	public void SetActivate(int n){

			nActive = n;

	}
}
