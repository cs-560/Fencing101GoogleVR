using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptmove : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void move(float move_by){
		transform.Translate (0.0f, 0.0f, move_by);
	}
}
