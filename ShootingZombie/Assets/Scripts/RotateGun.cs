using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGun : MonoBehaviour {

	private Vector3 target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		LookAtCursor();
	}

	void LookAtCursor()
    {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit rayHit;

		if(Physics.Raycast(ray, out rayHit))
        {
			target = rayHit.point;
        }

		transform.LookAt(target);
	}
}
