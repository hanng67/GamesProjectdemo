using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {

	private GameObject[] spawnPoint;
	public GameObject zoombie;
	private float minSpawnTime = 1;
	private float maxSpawnTime = 5;
	private float lastSpawnTime = 0;
	private float spawnTime = 0;

	// Use this for initialization
	void Start () {
		spawnPoint = GameObject.FindGameObjectsWithTag("Respawn");
		UpdateSpawnTime();
	}

	void UpdateSpawnTime()
    {
		lastSpawnTime = Time.time;
		spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
    }

	void Spawn()
    {
		int point = Random.Range(0, spawnPoint.Length);
		Instantiate(zoombie, spawnPoint[point].transform.position, Quaternion.identity);
		UpdateSpawnTime();
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time >= lastSpawnTime + spawnTime)
        {
			Spawn();
        }
	}
}
