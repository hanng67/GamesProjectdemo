using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	private float fireTime = 0.7f;
	private float lastFireTime = 0;
	private float damage = 1;
	private Animator anim;
	public GameObject smoke;
	public GameObject gunHead;
	private GameObject gameCtr;
	private float playerHealth = 10;
	private float currentPlayerHelth = 10;
	private AudioSource audioSource;
	public AudioClip audioPlayerDead;
	public Slider healthBar;

	// Use this for initialization
	void Start () {
		UpdateFireTime();
		anim = gameObject.GetComponent<Animator>();
		audioSource = gameObject.GetComponent<AudioSource>();
		gameCtr = GameObject.FindGameObjectWithTag("GameController");
		anim.SetBool("isShoot", false);
		healthBar.maxValue = playerHealth;
		healthBar.minValue = 0;
		healthBar.value = currentPlayerHelth;
	}

	void UpdateFireTime()
    {
		lastFireTime = Time.time;
    }
	
	public void GetHit(float damage)
    {
		if(currentPlayerHelth >= 0)
		{
			currentPlayerHelth -= damage;
			healthBar.value = currentPlayerHelth;
			audioSource.Play();
		}
        else
        {
			Dead();
        }

    }

	void Dead()
    {
		audioSource.clip = audioPlayerDead;
		audioSource.Play();
		gameCtr.GetComponent<GameController>().EndGame();
    }

	void Fire()
    {
		if (Time.time >= lastFireTime + fireTime)
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit rayHit;

			if (Physics.Raycast(gunHead.transform.position, gunHead.transform.forward, out rayHit))
			{

				if (rayHit.transform.parent.tag.Equals("Zombie"))
				{
					//rayHit.transform.parent.gameObject.GetComponent<ZombieController>().IsShooten = true;
					anim.SetBool("isShoot", true);
					InsSmoke();

					if (rayHit.transform.tag.Equals("ZombieHead"))
					{
						Destroy(rayHit.transform.gameObject);
						rayHit.transform.parent.gameObject.GetComponent<ZombieController>().Dead();
					}
                    else
                    {
						Destroy(rayHit.transform.gameObject);
						rayHit.transform.parent.gameObject.GetComponent<ZombieController>().GetHit(damage);
					}
					
					//rayHit.transform.gameObject.GetComponent<ZombieController>().GetHit(damage);
				}
			}

			UpdateFireTime();
		}
        else
        {
			anim.SetBool("isShoot", false);
		}
	}

	void InsSmoke()
    {
		GameObject sm = Instantiate(smoke, gunHead.transform.position, gunHead.transform.rotation) as GameObject;
		Destroy(sm, 0.5f);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
			Fire();
        }
	}
}
