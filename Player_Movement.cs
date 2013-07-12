using UnityEngine;
using System.Collections;

public class Player_Movement : MonoBehaviour {
	public float HorSpeed = 25f;
	public float VertSpeed = 5f;
	float base_height = 0f;
	float jump_height;
	float jump_amount = 5f;
	bool jumped;
	// Use this for initialization
	void Start () {
		jumped = false;
	}
	
	// Update is called once per frame
	void Update () {
		//if grounded
		if(rigidbody.velocity.y == 0f){
			base_height = transform.position.y;
			jump_height = base_height + jump_amount;  
			jumped = false;
		}
		//get input
		float Horiz = Input.GetAxisRaw("Horizontal");
		float Vert = Input.GetAxisRaw("Vertical");
		//if right or left is being pushed
		if(Horiz != 0){
			//if right is being pushed
	    	if(Horiz > 0){
				rigidbody.AddForce(transform.right * HorSpeed, ForceMode.Force);
			}
			//if left is being pushed
			else{
				rigidbody.AddForce(-transform.right * HorSpeed, ForceMode.Force);
			}
		}
		//if neither right nor left is being pushed
		else{
			rigidbody.velocity = new Vector3(0,rigidbody.velocity.y,0); 
		}
		//if below max jump height
		if(transform.position.y <= jump_height){
			//if pressing up or down
			if(Vert != 0){
				//if pressing up
				if(Vert > 0 && jumped == false){
					rigidbody.AddForce(transform.up * VertSpeed, ForceMode.Impulse);
					jumped = true;
				}
				//if player has already jumped
				else if(Vert > 0 && jumped == true){
					//do nothing
				}
			}
		}
		//player has hit max jump height
		else{
				rigidbody.velocity = new Vector3(rigidbody.velocity.x, -5f, 0);
		}
	}
}