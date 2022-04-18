using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    private Animator anim;
    private ThroughBoom throughBoom;
    private float monsterHealth = 5;
    private float monsterHealthRemain = 0;
    private int attackPower = 200;
    private int attackAngle = 45;
    public bool isBeingAttack;
    public bool isDead = false;
    public Slider healthSlide;

    GameObject gameController;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        anim.SetBool("isAttack", false);
        throughBoom = gameObject.GetComponent<ThroughBoom>();

        gameController = GameObject.FindGameObjectWithTag("GameController");
        monsterHealthRemain = monsterHealth;
        isBeingAttack = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            Attack();
            throughBoom.CalculateDirectionAttack(attackAngle, attackPower);
        }
    }

    void Attack()
    {
        if (Input.GetButtonDown("MonsterAttack") || isBeingAttack)
        {
            anim.SetBool("isAttack", true);
            throughBoom.InstantiateBoomAtPositionAttack(attackPower);
            isBeingAttack = false;
        }
        else
        {
            anim.SetBool("isAttack", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            monsterHealthRemain--;
            healthSlide.value = monsterHealthRemain;
            if (monsterHealthRemain == 0)
            {
                isDead = true;
                isBeingAttack = false;
                gameController.GetComponent<GameController>().isReward = true;
                monsterHealthRemain = monsterHealth;
            }
        }
    }
}
