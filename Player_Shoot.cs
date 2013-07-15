using UnityEngine;
using System.Collections;

public class Player_Shoot : MonoBehaviour {
	public GameObject projectile;
	
	public float speed = 1000;
	private PlayerAnimationController animation;
	//enum for character state
   
	// Use this for initialization
	void Start () {
		animation = GetComponent<PlayerAnimationController>();
		//projectile = GameObject.FindWithTag("bullet1");
	}
	
	// Update is called once per frame
	void Update () {
		//keyboard input
		if (Input.GetButtonDown("Fire1") || Input.GetKeyDown("space"))
		{
			
			
			//Player_Movement movement = GetComponent(Player_Movement); NOT WORKING.
			
			//Rigidbody instantiatedProjectile = Instantiate(projectile,transform.position,transform.rotation *  Quaternion.Euler(90, 0, 0)) as Rigidbody;
			GameObject instantiatedProjectile = Instantiate(projectile,transform.position,transform.rotation) as GameObject;
			Vector3 shootVector = Vector3.zero;
			
			//create movement
			if(animation.GetState() == PlayerAnimationController.State.StandingLeft || animation.GetState() == PlayerAnimationController.State.WalkLeft){
				//shoot left
				shootVector = Vector3.left;
			}
			else if(animation.GetState() == PlayerAnimationController.State.StandingRight || animation.GetState() == PlayerAnimationController.State.WalkRight){
				shootVector = Vector3.right;
			}
			else if(animation.GetState() == PlayerAnimationController.State.StandingAway || animation.GetState() == PlayerAnimationController.State.WalkAway){
				shootVector = Vector3.back;
			}
			else{
				shootVector = Vector3.forward;
			}
			
			instantiatedProjectile.rigidbody.AddForce(shootVector * speed, ForceMode.VelocityChange);
			
			

			//disable collisions between object and player
			//Physics.IgnoreCollision(instantiatedProjectile.collider, transform.root.collider);
			//instantiatedProjectile.collider.on
			
		}
	}
}
