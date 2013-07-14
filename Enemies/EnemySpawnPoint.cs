// EnemySpawnPoint.cs

using UnityEngine;
using System.Collections;

public class EnemySpawnPoint : MonoBehaviour {
	
	public GameObject enemy;
	
	public int enemiesToSpawn = 5;
	public int timeBetweenSpawns = 20;
	private ArrayList enemiesSpawned;
	
	// Use this for initialization
	void Start () {
		enemiesSpawned = new ArrayList();
		InvokeRepeating("SpawnNewEnemy", 5F, 10F);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void SpawnNewEnemy () {
		
		Debug.Log("Called SpawnNewEnemy");
		
		if(enemiesSpawned.Count < enemiesToSpawn){
			GameObject newEnemy = (GameObject) Instantiate(enemy, transform.position, transform.rotation);
			
			enemiesSpawned.Add(newEnemy);
		}
	}
}
