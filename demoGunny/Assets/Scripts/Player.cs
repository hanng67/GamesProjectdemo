using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Animator anim;
    private ThroughBoom throughBoom;
    private int attackPower;
    private int attackAngle;
    public Text txtAtkPower;
    public Text textLabel;
    private GameObject monster;

    [SerializeField]
    private Slider powerSlide;

    [SerializeField]
    private Slider healthSlide;

    private float playerHealth = 10;
    private float playerHealthRemain = 0;
    public float timeUpdate;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        anim.SetBool("isAttack", false);
        throughBoom = gameObject.GetComponent<ThroughBoom>();
        monster = GameObject.FindGameObjectWithTag("Monster");
        attackAngle = 45;
        playerHealthRemain = playerHealth;
        timeUpdate = Time.time;
        textLabel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (true)
        {
            if (Time.time >= timeUpdate + 0.03f)
            {
                timeUpdate = Time.time;
                GetAngle();
            }
            GetPower();
        }
        //CalculateMovement();

    }

    void CalculateMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector2 direction = new Vector2(horizontal, 0);
        if (Input.GetButton("Horizontal"))
        {
            if (horizontal >= 0)
            {
                transform.rotation = Quaternion.Euler(0,0,0);
            }
            else
            {
                Quaternion rotation = Quaternion.AngleAxis(180, Vector3.up);
                transform.rotation = rotation;
            }
        }

        transform.parent.transform.Translate(direction * 5.0f * Time.deltaTime);
    }

    void GetAngle()
    {
        if (Input.GetButton("Vertical"))
        {
            if (Input.GetAxis("Vertical") > 0)
            {
                attackAngle += 1;
            }
            else
            {
                attackAngle -= 1;
            }
            attackAngle = Mathf.Clamp(attackAngle, -30, 120);
        }
        throughBoom.CalculateDirectionAttack(attackAngle, attackPower);
    }

    void GetPower()
    {
        if (Input.GetButton("PlayerAttack"))
        {
            attackPower += 5;
            attackPower = Mathf.Clamp(attackPower, 0, 400);
        }
        else if (Input.GetButtonUp("PlayerAttack"))
        {
            anim.SetBool("isAttack", true);
            throughBoom.InstantiateBoomAtPositionAttack(attackPower);
            attackPower = 0;
            //Invoke("SendFlagAttack", 1.0f);
        }
        else
        {
            anim.SetBool("isAttack", false);
        }
        powerSlide.value = attackPower;
        txtAtkPower.text = "Attack Power: " + attackPower.ToString() + "\n" + "Attack Angle: " + attackAngle.ToString() + "degree";
    }

    void SendFlagAttack()
    {
        monster.GetComponent<Monster>().isBeingAttack = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            playerHealthRemain--;
            healthSlide.value = playerHealthRemain;
            if (playerHealthRemain == 0)
            {
                //Debug.Log("Fail");
                textLabel.gameObject.SetActive(true);
                Time.timeScale = 0;
                //playerHealthRemain = playerHealth;
            }
        }
    }
}
