using UnityEngine;
using System.Collections;

public class PlayerAnimationController : MonoBehaviour {

    //Storing the reference to RagePixelSprite -component
    private IRagePixel ragePixel;
     
    //enum for character state
    public enum State {
		Standing=0,
		StandingToward,
		StandingRight,
		StandingLeft,
		StandingAway,
		WalkRight,
		WalkLeft,
		WalkToward,
		WalkAway
	};
	
    private State state = State.Standing;
	private State prevState = State.Standing;

    void Start () {
        ragePixel = GetComponent<RagePixelSprite>();
		ragePixel.SetHorizontalFlip(false);
		ragePixel.PlayNamedAnimation("StayToward", false);
    }
	
	public State GetState(){
		return prevState;
	}
	
	public void SetAnimation(float Horizontal, float Vertical){
		//Check the keyboard state and set the character state accordingly
        if (Horizontal < (float) 0)
        {
            state = State.WalkLeft;
        }
        else if (Horizontal > (float) 0)
        {
            state = State.WalkRight;
        }
		else if (Vertical < 0)
        {
            state = State.WalkToward;
        }
        else if (Vertical > 0)
        {
            state = State.WalkAway;
        }
        else
        {
			switch(state){
				case(State.WalkToward):
					prevState = State.WalkToward;
					break;
				case(State.WalkAway):
					prevState = State.WalkAway;
					break;
				case(State.WalkLeft):
					prevState = State.WalkLeft;
					break;
				case(State.WalkRight):
					prevState = State.WalkRight;
					break;
			}
            state = State.Standing;
        }
        
		
		//Debug.Log(Input.GetAxisRaw("Vertical"));
		
        switch (state)
        {
            case(State.Standing):
				switch(prevState){
					case(State.WalkAway):
						//Reset the horizontal flip for clarity
		                ragePixel.SetHorizontalFlip(false);
		                ragePixel.PlayNamedAnimation("StayAway", true);
						break;
					case(State.WalkToward):
						//Reset the horizontal flip for clarity
		                ragePixel.SetHorizontalFlip(false);
		                ragePixel.PlayNamedAnimation("StayToward", true);
						break;
					case(State.WalkRight):
						//Reset the horizontal flip for clarity
		                ragePixel.SetHorizontalFlip(false);
		                ragePixel.PlayNamedAnimation("StayRight", true);
						break;
					case(State.WalkLeft):
						//Reset the horizontal flip for clarity
		                ragePixel.SetHorizontalFlip(true);
		                ragePixel.PlayNamedAnimation("StayRight", true);
						break;
				}
                break;
            case (State.WalkLeft):
                //Flip horizontally. Our animation is drawn to walk right.
                ragePixel.SetHorizontalFlip(true);
                //PlayAnimation with forceRestart=false. If the WALK animation is already running, doesn't do anything. Otherwise restarts.
                ragePixel.PlayNamedAnimation("WalkRight", false);
                break;
            case (State.WalkRight):
                //Not flipping horizontally. Our animation is drawn to walk right.
                ragePixel.SetHorizontalFlip(false);
                //PlayAnimation with forceRestart=false. If the WALK animation is already running, doesn't do anything. Otherwise restarts.
                ragePixel.PlayNamedAnimation("WalkRight", false);
                break;
			case (State.WalkToward):
                //Not flipping horizontally. Our animation is drawn to walk right.
                ragePixel.SetHorizontalFlip(false);
                //PlayAnimation with forceRestart=false. If the WALK animation is already running, doesn't do anything. Otherwise restarts.
                ragePixel.PlayNamedAnimation("WalkToward", false);
                break;
			case (State.WalkAway):
                //Not flipping horizontally. Our animation is drawn to walk right.
                ragePixel.SetHorizontalFlip(false);
                //PlayAnimation with forceRestart=false. If the WALK animation is already running, doesn't do anything. Otherwise restarts.
                ragePixel.PlayNamedAnimation("WalkAway", false);
                break;
        }
	}
}