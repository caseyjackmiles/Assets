// Level1Enemy.cs

using UnityEngine;
using System.Collections;

public class Level1Enemy : EnemyBase {
	
	// Override base speed for slower movement
	public override float movementSpeed
	{
		get { return .3F; }
		set { }
	}
}
