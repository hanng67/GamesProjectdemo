using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorfControl : MonoBehaviour {

	public GameObject boom;
	private float minBoomTime = 2.0f;
	private float maxBoomTime = 4.0f;
	private float lastBoomTime = 0;
	private float boomTime = 0;
	public float throughBoomTime = 0.3f;
	private GameObject sheep;
	private Animator anim;
	private GameObject gameController;

	// Use this for initialization
	void Start () {
		UpdateBoomTime();
		sheep = GameObject.FindGameObjectWithTag("Player");
		anim = gameObject.GetComponent<Animator>();
		gameController = GameObject.FindGameObjectWithTag("GameController");
		anim.SetBool("isBoom", false);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Time.time >= lastBoomTime + boomTime - throughBoomTime)
		{
			anim.SetBool("isBoom", true);
		}

		if (Time.time >= lastBoomTime + boomTime)
		{
			ThroughBoom();
			anim.SetBool("isBoom", false);
		}
	}

	void UpdateBoomTime()
    {
		lastBoomTime = Time.time;
		boomTime = Random.Range(minBoomTime, maxBoomTime + 1);
	}

	void ThroughBoom()
	{
		GameObject bom = Instantiate(boom, transform.position, Quaternion.identity) as GameObject;

		bom.GetComponent<BoomControl>().target = sheep.transform.position;

		UpdateBoomTime();

		gameController.GetComponent<GameController>().GetPoint();
	}
}
