using UnityEngine;
using System.Collections;

public class Bullet_Collide : MonoBehaviour {
	
	void OnCollisionEnter(Collision collide) {
		if(collide.gameObject.tag != "Player"){
			Destroy (gameObject);
		}
	}
	
}
