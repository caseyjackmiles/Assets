using UnityEngine;
using System.Collections;

public class Player_Side_Collider : MonoBehaviour {

	void OnTriggerEnter(Collider Other){
		if(Other.tag == "Enemy"){
			//kill parent of this script
			Destroy (transform.parent.gameObject);
		}
	}
}
