using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdCotroller : MonoBehaviour {

	public float flyPower;

	public AudioClip flyClip;
	public AudioClip gameOverClip;
	private AudioSource audioSource;

	private GameObject obj;
	private GameObject gameController;
	private Animator anim;

	// Use this for initialization
	void Start () {
		obj = gameObject;
		audioSource = obj.GetComponent<AudioSource>();
		audioSource.clip = flyClip;
		flyPower = 1000;
		anim = obj.GetComponent<Animator>();
		anim.SetFloat("flyPower", 0);
		anim.SetBool("isDead", false);


		if (gameController == null)
		{
			gameController = GameObject.FindGameObjectWithTag("GameController");
		}
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0) && (!gameController.GetComponent<GameController>().isEndGame))
        {
			audioSource.Play();
			obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, flyPower));
        }
		anim.SetFloat("flyPower", obj.GetComponent<Rigidbody2D>().velocity.y);
	}

	void OnTriggerEnter2D(Collider2D other)
    {
		gameController.GetComponent<GameController>().GetPoint();
	}

	void OnCollisionEnter2D(Collision2D other)
    {
		anim.SetBool("isDead", true);
		audioSource.clip = gameOverClip;
		audioSource.Play();
		gameController.GetComponent<GameController>().EndGame();
    }
}
