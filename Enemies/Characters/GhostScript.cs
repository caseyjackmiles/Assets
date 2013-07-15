// GhostScript.cs

using UnityEngine;
using System.Collections;

public class GhostScript : EnemyBase {
	
	// Override base speed for slower movement
	public override float movementSpeed
	{
		get { return 3F; }
		set { }
	}
}
