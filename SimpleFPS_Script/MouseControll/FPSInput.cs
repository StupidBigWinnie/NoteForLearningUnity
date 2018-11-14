using UnityEngine;
using System.Collections;

public class FPSInput : MonoBehaviour{
	public float speed = 10.0f;
	public float gravity = -9.8f;

	private CharacterController _charController;

	void Start(){
		_charController = GetComponent<CharacterController>();
	}
	
	void Update(){
		//1.Get input
		float deltaX = Input.GetAxis("Horizontal") * speed;
		float deltaZ = Input.GetAxis("Vertical") * speed;

		//2.Construct a vector based on input
		Vector3 movement = new Vector3(deltaX, 0f, deltaZ);
		
		//3.Make sure the character acts like what we want
		movement = Vector3.ClampMagnitude(movement, speed); //Returns a copy of vector with its magnitude clamped to maxLength
		movement.y = gravity; //Stay on the floor
		movement *= Time.deltaTime; //Something related to frame
		movement = transform.TransformDirection(movement); //Local(for character's view) not global

		//4.Output
		_charController.move(movement);


	}
}

//note1:
//	Time.deltaTime
//	behave in a same way on different computer
//	30fps -> 1/30; 60fps -> 1/60; which gives a same behabiour in one second.
//note2:
//	ClampMagnitude() helps the vector stay in a limitation on the diagonal movement.
//note3:
//	gravity helps character stay on the floor(prevent flying since the changement of terrain)