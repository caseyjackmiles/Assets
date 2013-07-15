// EnemyBase.cs

using UnityEngine;
using System.Collections;

public class EnemyBase : MonoBehaviour {
	
	// Enemy properties, override in child classes if desired
	public virtual int startingHealthPoints
	{
		get { return 10; }
		set { }
	}
	
	public virtual bool canCauseDamage
	{
		get { return true; }
		set { }
	}
	
	public virtual int damagePower
	{
		get { return 1; }
		set { }
	}
	
	public virtual float movementSpeed
	{
		get { return 10F; }
		set { }
	}
	
	public enum Axes
	{
		moveX,
		moveZ
	};
	
	public enum Directions
	{
		moveNeg,
		movePos
	};
	
	private int health;
	private Axes movementAxis;
	private Directions movementDirection;
	
	
	// A Transform object for enemies to lookAt
	Transform target;

	// Use this for initialization
	void Start () {
		
		// Find the Player object, if it exists
		GameObject player = GameObject.Find("Player");
		if(player)
			target = player.transform;
		
		// Start repeating the movement function
		// Check which direction to move once a second
		InvokeRepeating("getDirection", 0F, 1F);
	}
	
	// Update is called once per frame
	public virtual void Update () {
	
		move();
	}
	
	// Called when an enemy hits another object
	// E.g., the player, a bullet, etc.
	public virtual void onTriggerEnter (Collider other) {
		
	}
	
	public virtual void move() {
		
		switch(movementAxis)
		{
		case Axes.moveX:
			if (movementDirection == Directions.movePos)
				gameObject.transform.Translate(Time.deltaTime * movementSpeed, 0, 0);
			else
				gameObject.transform.Translate(Time.deltaTime * movementSpeed * -1, 0, 0);
			break;
			
		case Axes.moveZ:
			if (movementDirection == Directions.movePos)
				gameObject.transform.Translate(0, 0, Time.deltaTime * movementSpeed);
			else
				gameObject.transform.Translate(0, 0, Time.deltaTime * movementSpeed * -1);
			break;
		}

	}
	
	public void getDirection() {
		
		if(target){
			
			//Only need to check the forward and right dimensions
			float forwardDiff = target.transform.position.z - gameObject.transform.position.z;
			float rightDiff   = target.transform.position.x - gameObject.transform.position.x;
			
			if((Mathf.Abs(rightDiff)) >= (Mathf.Abs(forwardDiff)))
			{
				Debug.Log("Should move left/right");
				//gameObject.transform.Translate(Time.deltaTime * movementSpeed * rightDiff, 0, 0);
				movementAxis = Axes.moveX;
				if(rightDiff >= 0)
					movementDirection = Directions.movePos;
				else
					movementDirection = Directions.moveNeg;
			}
			else {
				Debug.Log("Should move forward/back");
				//gameObject.transform.Translate(0, 0, Time.deltaTime * movementSpeed * forwardDiff);
				movementAxis = Axes.moveZ;
				if(forwardDiff >= 0)
					movementDirection = Directions.movePos;
				else
					movementDirection = Directions.moveNeg;
			}
		}
	}
}
