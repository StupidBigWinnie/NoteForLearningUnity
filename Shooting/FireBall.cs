using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour{
	public float BallSpeed = 20.0f;
	public int damage = 1;

	void Start(){

	}

	void Update(){
		//Fly the ball!
		transform.Translate(0f, 0f, BallSpeed * Time.DeltaTime);
	}

	void OnTriggerEnter(Collider coll){
		PlayerCharacter player = coll.GetComponent<PlayerCharacter>();
		if(player != null){ //the ball has collides with a Player
			player.Hurt(damage); //Hurt() defined in PlayerCharacter, which updates the player's status.
		}
	}
}

//OnTriggerEnter(coll) will be called when the collider enters coll.
//Send message to the *trigger* collider.
//Add contents in OnTriggerEnter to do something.
//	-hurt that coll
//	-give coll a reward
//	-trigger an event(a conversation/battle/transformation/...)