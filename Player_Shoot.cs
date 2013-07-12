using UnityEngine;
using System.Collections;

public class Player_Shoot : MonoBehaviour {
	public Rigidbody projectile;
	
	public float speed = 20;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//keyboard input
		if (Input.GetButtonDown("Fire1"))
		{
			
			
			Rigidbody instantiatedProjectile = Instantiate(projectile,transform.position,transform.rotation *  Quaternion.Euler(90, 0, 0)) as Rigidbody;
			
			//create movement
			instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed));
			
			//disable collisions between object and player
			//Physics.IgnoreCollision(instantiatedProjectile.collider, transform.root.collider);
			//instantiatedProjectile.collider.on
			
		}
	}
}
