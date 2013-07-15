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
		get { return 1F; }
		set { }
	}
	
	private int health;
	
	
	// A Transform object for enemies to lookAt
	Transform target;

	// Use this for initialization
	void Start () {
		
		// Find the Player object, if it exists
		GameObject player = GameObject.Find("Player");
		if(player)
			target = player.transform;	
	}
	
	// Update is called once per frame
	public virtual void Update () {
	
		lookAtPlayer();
		move();
	}
	
	// Called when an enemy hits another object
	// E.g., the player, a bullet, etc.
	public virtual void onTriggerEnter (Collider other) {
		
	}
	
	// Function to cause all enemies to look at the player object
	void lookAtPlayer () {
		if(target)
			transform.LookAt(target);
	}
	
	public virtual void move() {
		if(target)
			transform.position = Vector3.Lerp(transform.position, target.position, movementSpeed * Time.deltaTime);
	}
}
