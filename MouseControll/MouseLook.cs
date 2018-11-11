using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour{
	public enum RotationAxes{
		MouseXandY = 0;
		MouseX = 1;
		MouseY = 2;
	}
	public RotationAxes axes = RotationAxes.MouseXandY;
	public float sensitiveHor = 9.0f;
	public float sensitiveVer = 9.0f;
	public float maxVer = 45.0f;
	public float minVer = -45.0f;

	private float _RotationX = 0;

	void Start(){
		RigidBody body = GetComponent<RigidBody>();
		if(body != null){
			body.freezeRotation = true; //⭐
		}
	}

	void Update(){
		if(axes == RotationAxes.MouseX){
			transform.Rotate(0f, Input.GetAxis("MouseX") * sensitiveHor, 0f);
		}
		else if(axes == RotationAxes.MouseY){
			_RotationX -= Input.GetAxis("MouseY") * sensitiveVer; //focus on -=
			_RotationX = Mathf.Clamp(_RotationX, minVert, maxVert);

			float RotationY = transform.LocalEulerAngles.y; //donnot use Rotation here
			transform.LocalEulerAngles = new Vector3(_RotationX, RotationY, 0f); //Global and Local
		}
		else{ //both vertical and Horizontal movement
			_RotationX -= Input.GetAxis("MouseY") * sensitiveVer;
			_RotationX = Mathf.Clamp(_RotationX, minVert, maxVert);

			float delta = Input.GetAxis("MouseX") * sensitiveHor;
			float RotationY = transform.LocalEulerAngles.y + delta; 

			transform.LocalEulerAngles = new Vector3(_RotationX, RotationY, 0f);
		}
	}

}

//note1:
//	MouseX -> Horizontal -> on y axis
//	MouseY -> Vertical -> on x axis
//note2:
//	Mathf.Clamp helps camera not to keep rotating when over +-45 degree
//	Therefore:
//		-using Euler angle
//		-Local(not global) angle
//		-update(not new) angle
//note3:
//	freezeRotation makes sure that the Rotation is only contrlled by MouseInput instead of environment in Game
//note4:
//	functions:
//		-Mathf.Clamp(num, min, max)
//		-GetComponent<ClassName>()
//		-transform.Rotate(Vector3)
//		-transform.LocalEulerAngle
//		-Input.GetAxis("KeyName")
