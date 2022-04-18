using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomControl : MonoBehaviour {

	public Vector3 target;
	public float moveSpeed = 5.0f;
	private float destroyTime = 2.0f;
	public GameObject explor;

	// Use this for initialization
	void Start () {
		Destroy(gameObject, destroyTime);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.Lerp(transform.position, target, moveSpeed * Time.deltaTime);

		//transform.Translate((transform.position - target) * moveSpeed * Time.deltaTime * (-1));
	}

	void OnDestroy()
    {
		GameObject exp = Instantiate(explor, transform.position, Quaternion.identity) as GameObject;
		Destroy(exp, 0.3f);
    }
}
