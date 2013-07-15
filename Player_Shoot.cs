using UnityEngine;
using System.Collections;

public class Player_Shoot : MonoBehaviour {
	public Rigidbody projectile;
	
	public float speed = 20;
	private PlayerAnimationController animation;
	//enum for character state
   
	// Use this for initialization
	void Start () {
		animation = GetComponent<PlayerAnimationController>();
	}
	
	// Update is called once per frame
	void Update () {
		//keyboard input
		if (Input.GetButtonDown("Fire1") || Input.GetKeyDown("space"))
		{
			
			
			//Player_Movement movement = GetComponent(Player_Movement); NOT WORKING.
			
			Rigidbody instantiatedProjectile = Instantiate(projectile,transform.position,transform.rotation *  Quaternion.Euler(270, 0, 0)) as Rigidbody;
			
			//create movement
			if(animation.GetState() == PlayerAnimationController.State.StandingLeft || animation.GetState() == PlayerAnimationController.State.WalkLeft){
				//shoot left
				instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(-speed,0,0));
			}
			else if(animation.GetState() == PlayerAnimationController.State.StandingRight || animation.GetState() == PlayerAnimationController.State.WalkRight){
				instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(speed,0,0)); 
			}
			else if(animation.GetState() == PlayerAnimationController.State.StandingAway || animation.GetState() == PlayerAnimationController.State.WalkAway){
				instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0,0,speed)); 
			}
			else{
				instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0,0,-speed)); 
			}
			

			//disable collisions between object and player
			//Physics.IgnoreCollision(instantiatedProjectile.collider, transform.root.collider);
			//instantiatedProjectile.collider.on
			
		}
	}
}
