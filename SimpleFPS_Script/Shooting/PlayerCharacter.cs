using UnityEngine;
using System.Collections;

public class PlayerCharacter : MonoBehaviour{

	private int health;

	void Start(){
		health = 10;
	}

	public void Hurt(int damage){
		health -= damage;
		if(health == 0){
			Destroy(this.gameObject);
		}
	}

}

//A basic playerCharacter information system;
//To manage Player's status.
//Want:
//	-Strength/Defence/...
//	-Recover()/StrGrow()/DefGrow()/...