using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("Item Type")]
    public bool isItem;
    public bool isWeapon;
    public bool isArmor;

    [Header("Item Details")]
    public string itemName;
    [TextArea(5,1)]
    public string description;
    public int value;
    public Sprite itemSprite;
    [Space]
    public int amountToChange;
    public bool affectHP, affectMP, affectStr;

    [Header("Weapon/Armor Details")]
    public int weaponStrength;

    public int armorStrength;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
