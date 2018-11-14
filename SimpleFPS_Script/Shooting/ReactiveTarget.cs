using UnityEngine;
using System.Collections;

public class ReactiveTarget : MonoBehaviour{
	public void ReactToHit(){
		StartCoroutine(Die());

		//Maybe some code
	}

	private IEnumerator Die(){
		//Some performance
		this.transform.Rotate(-75, 0, 0);

		//to give some time for animations(?)
		yield return WaitForSeconds(1.5f); //continue until WaitDorSeconds has finished

		Destroy(this.GameObject); //directly vanishΣ(っ °Д °;)っ
	}
}

//Note1:
//	structure:
//	-ReactToHit
//	(StartCoroutine)
//		-Reaction1
//		-Reaction2...
//		-Die