using UnityEngine;
using System.Collections;

public class Top_collider_trigger : MonoBehaviour {

	public float bounce_force = 2f;
	
	void OnTriggerEnter(Collider Other){
		if(Other.tag == "Player"){
			//make Other bounce
			Other.rigidbody.AddForce(Vector3.up * bounce_force, ForceMode.Impulse);
			//kill parent of this script
			Destroy (transform.parent.gameObject);
		}
	}
	
	
}
