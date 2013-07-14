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
		if (Input.GetButtonDown("Fire1") || Input.GetKeyDown("space"))
		{
			
			Player_Movement movement = new Player_Movement();
			//Player_Movement movement = GetComponent(Player_Movement); NOT WORKING.
			
			Rigidbody instantiatedProjectile = Instantiate(projectile,transform.position,transform.rotation *  Quaternion.Euler(270, 0, 0)) as Rigidbody;
			
			//create movement
			
			//Vector3 shootVector = new Vector3(0,0,speed);
			//instantiatedProjectile.velocity = transform.TransformDirection(shootVector);
			if(movement.Horiz != 0){
				if(movement.Horiz > 0){
					instantiatedProjectile.AddForce(transform.right * speed*2, ForceMode.Force);
				}
				else{
					instantiatedProjectile.AddForce(-transform.right * speed*2, ForceMode.Force);
				}
			}
			else{
				instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0,instantiatedProjectile.velocity.y*2,speed)); 
			}
			//disable collisions between object and player
			//Physics.IgnoreCollision(instantiatedProjectile.collider, transform.root.collider);
			//instantiatedProjectile.collider.on
			
		}
	}
}
