using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour {

	public float moveSpeed;
	public float moveRange;

	private Vector3 oldPosition;
	private GameObject obj;

	// Use this for initialization
	void Start () {
		obj = gameObject;
		moveSpeed = 2.0f;
		moveRange = 7.1f;
		oldPosition = obj.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		obj.transform.Translate(new Vector3(- 1 * Time.deltaTime * moveSpeed, 0, 0));

		if(Vector3.Distance(oldPosition, obj.transform.position) > moveRange)
        {
			obj.transform.position = oldPosition;
        }
	}
}
