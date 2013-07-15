using UnityEngine;
using System.Collections;

public class Bullet_Collide : MonoBehaviour {
	public float speed = 1000;
	
	
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
