using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepControl : MonoBehaviour {

	private Vector3 mousePos;
	public float moveSpeed = 20;
	public float minX = -5.5f;
	public float maxX = 5.5f;
	public float minY = -3.0f;
	public float maxY = 3.0f;
	private GameObject gameController;

	// Use this for initialization
	void Start () {
		mousePos = transform.position;
		gameController = GameObject.FindGameObjectWithTag("GameController");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
			mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			mousePos = new Vector3(Mathf.Clamp(mousePos.x, minX, maxX), Mathf.Clamp(mousePos.y, minY, maxY), 0);
		}
		transform.position = Vector3.Lerp(transform.position, mousePos, moveSpeed * Time.deltaTime);
		//transform.Translate((transform.position - mousePos) * moveSpeed * Time.deltaTime * (-1));
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		Destroy(other.gameObject);
		gameController.GetComponent<GameController>().EndGame();
	}
}
