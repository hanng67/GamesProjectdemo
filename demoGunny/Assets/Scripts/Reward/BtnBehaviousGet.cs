using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnBehaviousGet : MonoBehaviour
{
    public GameObject Inventory;
    public RandomItems ItemGet;
    private GameObject monster;
    // Start is called before the first frame update
    void Start()
    {
        monster = GameObject.FindGameObjectWithTag("Monster");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetItemToInventory()
    {
        monster.GetComponent<Monster>().isDead = false;
        monster.GetComponent<Monster>().healthSlide.value = 5;
        Inventory.GetComponent<Inventory>().AddItems(ItemGet.Item);
        ItemGet.isRandomTimeOut = false;
        transform.parent.gameObject.SetActive(false);
    }
}
