using UnityEngine;
using System.Collections;

public class Player_Shoot2 : MonoBehaviour {

	public GameObject bullet = null;
	public float bulletspeed = 500000F;
	private PlayerAnimationController animation;
	
	void Start(){
		animation = transform.parent.GetComponentInChildren<PlayerAnimationController>();
	}
	
	void Update () {
		if(Input.GetKeyDown("space")){
			GameObject shot;
			Vector3 shootVector;
			
			if(animation.GetState() == PlayerAnimationController.State.WalkLeft || animation.GetState() == PlayerAnimationController.State.StandingLeft){
				shot = GameObject.Instantiate(bullet, transform.position, transform.rotation) as GameObject;
				shootVector = Vector3.left;
			}
			else if(animation.GetState() == PlayerAnimationController.State.WalkRight || animation.GetState() == PlayerAnimationController.State.StandingRight){
				shot = GameObject.Instantiate(bullet, transform.position + (Vector3.right), transform.rotation) as GameObject;
				shootVector = Vector3.right;
			}
			else if(animation.GetState() == PlayerAnimationController.State.WalkToward || animation.GetState() == PlayerAnimationController.State.StandingToward){
				shot = GameObject.Instantiate(bullet, transform.position, transform.rotation) as GameObject;
				shootVector = Vector3.back;
			}
			else{
				shot = GameObject.Instantiate(bullet, transform.position + (Vector3.right), transform.rotation) as GameObject;
				shootVector = Vector3.forward;
			}
			
			
			//shot.rigidbody.AddForce(transform.forward * bulletspeed);
			shot.rigidbody.AddForce(shootVector * bulletspeed);
		}
	}
}
