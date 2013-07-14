using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	//define speed constants for player
	const float Speed = 10F;
	const float JumpHeight = 5F;
	private bool has_jumped;
	
	public void setHasJumped(bool jump){
		has_jumped = jump;
	}
	
	// Use this for initialization
	void Start () {
		has_jumped = false;
	}
	
	// Update is called once per frame
	void Update () {
		//grab input keys
		float Horizontal = Input.GetAxisRaw("Horizontal");
		float Vertical = Input.GetAxisRaw("Vertical");
		//check for player movement
		Move_Player(Horizontal, Vertical);
		//change animation accordingly
		transform.GetComponentInChildren<PlayerAnimationController>().SetAnimation(Horizontal, Vertical);
		
		//Don't want jump anymore. Spacebar should be mapped to shooting
		//Jump(Input.GetKeyDown("space"));
	}
	
	public void Move_Player(float Horizontal, float Depth){
		//if no arrow keys are being pushed, return
		if(Horizontal == 0 && Depth == 0)
			return;
		//if right arrow key is being pushed
		if(Horizontal > 0){
			transform.Translate(Vector3.right * Speed * Time.deltaTime);
		}
		//if left arrow key is being pushed
		else if(Horizontal < 0){
			transform.Translate(Vector3.left * Speed * Time.deltaTime);
		}
		//if up arrow key is being pushed
		if(Depth > 0){
			transform.Translate(Vector3.forward * Speed * Time.deltaTime);
		}
		//if down arrow key is being pushed
		else if(Depth < 0){
			transform.Translate(Vector3.back * Speed * Time.deltaTime);
		}
	}
	
	public void Jump(bool Jump){
		if(Jump == true && has_jumped == false){
			rigidbody.AddForce(Vector3.up * JumpHeight, ForceMode.Impulse);
			has_jumped = true;
		}
	}
}
