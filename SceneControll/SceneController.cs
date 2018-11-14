using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour{
	private GameObject EnermyPrefab; //A prefab for enermy:wanderingAI
	private GameObject _enermy;

	void Start(){

	}

	void Update(){
		if(_enermy == null){
			//Set an enermy instance and its position & rotation
			_enermy = Instantiate(EnermyPrefab) as GameObject;
			_enermy.transform.position = new Vector3(0, 1, 0);
			float angle = Random.Range(-90, 90);
			_enermy.transform.Rotate(0, angle, 0);

		}
	}

}