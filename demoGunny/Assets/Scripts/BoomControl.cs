using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomControl : MonoBehaviour
{
    public GameObject Exploision;
    public string ObjAttackTag;
    private Rigidbody2D rigid;
    private GameObject monster;

    private void Start()
    {
        gameObject.tag = ObjAttackTag;
        rigid = gameObject.GetComponent<Rigidbody2D>();
        monster = GameObject.FindGameObjectWithTag("Monster");
    }

    private void Update()
    {
        float angle = Mathf.Atan2(rigid.velocity.x, rigid.velocity.y) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rotation;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (ObjAttackTag == "Player")
        {
            monster.GetComponent<Monster>().isBeingAttack = true;
        }
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (ObjAttackTag != collision.gameObject.tag)
        {
            if (ObjAttackTag == "Player")
            {
                monster.GetComponent<Monster>().isBeingAttack = true;
            }
            Destroy(this.gameObject);
        }
    }

    private void OnDestroy()
    {
        GameObject explore = Instantiate(Exploision, this.gameObject.transform.position, Quaternion.identity) as GameObject;
        Destroy(explore, 1.12f);
    }
}
