using UnityEgine;
using System.Collections;

public class ClassName : MonoBehaviour{
	public float arg1 = 1.0f;

	private float arg2 = 2.0f;

	void Awake(){

	}

	void Start(){

	}
	
	void FixedUpdate(){
		//e.g. add force before the physical transformation
		//may be more accurate(guess: it is related to the local angle)
	}

	void Update(){
		//e.g. make tranformation
	}
	
	void LateUpdate(){
		//e.g. the camera follows the player after updating the position
	}

}
