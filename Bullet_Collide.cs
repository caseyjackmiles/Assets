using UnityEngine;
using System.Collections;

public class Bullet_Collide : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter(Collision collide) {
		Destroy (gameObject);	
	}
}
