using UnityEngine;
using System.Collections;

public class PlayerJumpCollider : MonoBehaviour {
	void OnTriggerEnter(Collider other){
		//if(other.tag == "Ground") //consider re-instating this if it gets messy
			transform.parent.gameObject.GetComponent<PlayerMovement>().setHasJumped(false);
	}
}
