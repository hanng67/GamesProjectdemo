using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour {

	private float moveSpeed;
	private float minMoveSpeed = 0.01f;
	private float maxMoveSpeed = 0.1f;
	private float rangeAttack = 20;
	private float lastIncreaseTime;
	private float timeIncrease;

	private GameObject player;
	private GameObject lookAtTarget;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		lookAtTarget = GameObject.FindGameObjectWithTag("LookTarget");
		UpdateTimeIncrease();
		UpdateMoveSpeed();
	}

	void UpdateTimeIncrease()
    {
		lastIncreaseTime = Time.time;
	}

	void UpdateMoveSpeed()
    {
		moveSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);
    }

	void Move()
    {
		if (player == null || lookAtTarget == null)
			return;
		if(Vector3.Distance(transform.position, player.transform.position) > rangeAttack)
		{
			transform.LookAt(lookAtTarget.transform.position);
			transform.position = Vector3.Lerp(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
		}
        else
        {
			transform.gameObject.GetComponent<Animator>().SetBool("isIdle", true);
			transform.gameObject.GetComponent<ZombieController>().isAttack = true;
			transform.gameObject.GetComponent<MoveToPlayer>().enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		Move();
		if(Time.time >= lastIncreaseTime + timeIncrease)
        {
			moveSpeed += 0.1f * Time.deltaTime;
			UpdateTimeIncrease();
		}
	}
}
