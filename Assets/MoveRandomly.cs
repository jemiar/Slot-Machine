using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRandomly : MonoBehaviour {

	public Vector3 currentPos; //store current position
	public Vector3 target; //store target position
	public bool clickable; //used to check if the capsule is clickable. If it is moving, it is unclickable

	// Use this for initialization
	void Start () {
		//At the begining, set the current position, and make sure the capsule is clickable
		currentPos = transform.position;
		clickable = true;
	}
	
	// Update is called once per frame
	void Update () {
		//If the capsule hasn't reached its target, continue to move it
		if (Vector3.Magnitude (target - currentPos) > 0.1f) {
			transform.Translate ((target - currentPos) / 60);
			currentPos += (target - currentPos) / 60;
		} else { //when it reaches its target, make it clickable again
			clickable = true;
		}
	}

	void OnMouseDown() {
		//when click on capsule, make sure it is clickable
		if (clickable) {
			//set the current target
			currentPos = transform.position;
			//spawn a new random target
			target = new Vector3 (Random.Range(-5.0f, 5.0f), Random.Range(-5.0f, 5.0f), Random.Range(-5.0f, 5.0f));
		}
		//after setting value, make the capsule unclickable
		clickable = false;
	}
}
