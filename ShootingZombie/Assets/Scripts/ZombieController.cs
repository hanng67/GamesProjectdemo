using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour {

	private float zombieHealth = 3;
	private Animator anim;
	private bool isShooten;
	private float lastShootTime = 0;
	private float shootTime = 0.1f;
	public bool isAttack = false;
	private float lastAttackTime = 0;
	private float attackTime = 0.2f;
	private AudioSource audioSource;
	public AudioClip audiZombieDead;
	private GameObject player;
	private float damage = 1;
	private GameObject gameCtr;
	public bool IsShooten
    {
        get { return isShooten; }
        set
        {
			isShooten = value;
			anim.SetBool("isShooten", isShooten);
			UpdateTimeAnim();
		}
    }

	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator>();
		audioSource = gameObject.GetComponent<AudioSource>();
		player = GameObject.FindGameObjectWithTag("Player");
		gameCtr = GameObject.FindGameObjectWithTag("GameController");
		IsShooten = false;
		anim.SetBool("isDead", false);
	}

	void UpdateTimeAnim()
    {
		lastShootTime = Time.time;
    }

	void ShootenAnim(bool isShooten)
    {
		anim.SetBool("isShooten", isShooten);
	}

	public void GetHit(float dame)
    {
		//IsShooten = true;
		zombieHealth -= dame;
		audioSource.Play();
		if (zombieHealth <= 0)
        {
			Dead();
        }
        else
        {
			IsShooten = true;
		}
    }

	public void Dead()
	{
		audioSource.clip = audiZombieDead;
		audioSource.Play();
		anim.SetBool("isDead", true);
		gameCtr.GetComponent<GameController>().GetPoint();
		Destroy(gameObject, 1f);
    }

	void UpdateAttackTime()
    {
		lastAttackTime = Time.time;
	}

	void AttackAnim()
    {
		if(Time.time >= lastAttackTime + attackTime)
        {
			anim.SetBool("isAttack", true);
			player.GetComponent<PlayerController>().GetHit(damage);
			player.GetComponent<Light>().enabled = true;
			UpdateAttackTime();
		}
        else
		{
			player.GetComponent<Light>().enabled = false;
			anim.SetBool("isAttack", false);
		}
		
    }
	
	// Update is called once per frame
	void Update () {
        if (IsShooten && Time.time >= lastShootTime + shootTime)
        {
			IsShooten = false;
        }
        if (isAttack)
        {
			AttackAnim();
        }

	}
}
