using UnityEngine;
using System.Collections;

public class WanderingAI : MonoBehaviour{
	public float speed = 9.0f;
	public float obstacleRange = 5.0f

	[SerializedField] private GameObject FireBallPrefab;
	private GameObject fireball;

	void Start(){

	}

	void Update(){
		//Move
		transform.Translate(0, 0, speed * time.DeltaTime);

		//Detect whether there is an obstacle or a Player
		Ray ray = new ray(transform.position, transform.forward);
		RaycastHit hit;
		if Physics.SphereCast(ray, 0.75f, out hit){ //Using SphereCast to detect collision easier
			GameObject hitObject = hit.transform.gameObject;
			if(hitObject.GetComponent<PlayerCharacter>()){ //Facing a Player -> shooting
				if(fireball == null){
					//Instantiate a fireball, and set its position & rotation

					fireball = Instantiate(FireBallPrefab) as GameObject; 
					//FireBall Script will be attached to FireBallPrefab, setting its speed and damage.
					
					fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f); //from local to global!
					fireball.transform.rotation = transform.rotation;
				}
			}
			else if(hit.distance < obstacleRange){ //Facing an obstacle -> turning around
				float angle = Random.Range(-100, 100); //randomly pick another direction to move forward
				transform.Rotate(0, angle, 0);
			}
		}

	}

}

//Note1:
//	SphereCast(Vector3 origin, float radius, Vector3 forward)
//	Sweep a sphere in this direction and to detect whether collide into something.
//	Make detection easier;
//Note2:
//	Transform information:
//	-TransformPoint
//		transform the local position to global
//	-Vector3.forward/right/left...
//		local position
//Prefabs:
//	Objects with particular properties used many times can be instantiated through Prefabs;
//	Edit this prefab, then all of its instances will do the same modification.
