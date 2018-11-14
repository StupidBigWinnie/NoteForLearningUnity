using UnityEngine;
using System.Collections;

public class RayShooter : MoneBehaviour{

	private Camera cam;

	void Start(){
		Camera cam = GetComponent<Camera>(); //1:get current camera

		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visable = false;
	}

	void Update(){
		if(GetMouseButtonDown(0)){
			//press LM;
			Vector3 point = new Vector3(cam.pixelWidth/2, cam.pixelHeight/2, 0f); //center of the screen
			//want:code for actions/animations of gunshot 
			Ray ray = cam.ScreenPointToRay(point); //Ray object : help to select stn. on the screen(or simulate gunshot)
			RaycastHit hit; //use Ray to simulate a bullet
			//RaycastHit : a bunch of information of this ray, including the point of hit place.

			if(Physics.Raycast(ray, out hit)){ //To detect whether this ray hit something in the scene
				//StartCoroutine(HitSomething(hit.point)); 
				//Since ReactiveTarget has been given, let's use ReactToHit!
				StartCoroutine(HitSomething(hit.collider)); //this collider has the ReactiveTarget component
			}
		}
	}

	private IEnumerator HitSomething(Collider coll){ //The coroutine
		//code for reacting to being hit
		coll.ReactToHit();
	}

	void OnGUI(){
		int size = 12;
		float posX = cam.pixelWidth/2 - size/4;
		float posY = cam.pixelHeight/2 - size/2;

		GUI.Label(new rect(posX, posY, size, size), "*"); //a rectangle region with the "*" pattern
	}
}

//Note1:
//	RaycastHit's useful prop:
//		-point
//		-collider
//		-distance
//Note2:
//	public Coroutine StartCoroutine(IEnumerator routine);
//	2 way of usage: 
//		-invoke coroutine and continue exercuting the function;
//		-invoke coroutine and wait until it has finished; (use yield return)
//Note3:
//	GUI.Label(rect position, string text);