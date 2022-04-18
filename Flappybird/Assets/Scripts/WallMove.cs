using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMove : MonoBehaviour {

	public float moveSpeed;

	public float oldPosition;
	private GameObject obj;
	private AudioSource audioSource;
	private float minY;
	private float maxY;

	// Use this for initialization
	void Start()
	{
		obj = gameObject;
		audioSource = obj.GetComponent<AudioSource>();
		moveSpeed = 2.0f;
		oldPosition = 10;
		minY = -0.7f;
		maxY = 2.0f;
	}

	// Update is called once per frame
	void Update()
	{
		obj.transform.Translate(new Vector3(-1 * Time.deltaTime * moveSpeed, 0, 0));
	}

	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("ResetWall"))
        {
			obj.transform.position = new Vector3(oldPosition, Random.Range(minY, maxY), 0);
		}
		if (other.gameObject.tag.Equals("Player"))
		{
			audioSource.Play();
		}
	}
}
