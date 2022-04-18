using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject[] inventory = new GameObject[5];
    public bool itemAdd = false;
    ExportDataToJason exportData;
    public void Start()
    {
        exportData = gameObject.GetComponent<ExportDataToJason>();
    }
    public void AddItems(GameObject item)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)
            {
                inventory[i] = item;
                Debug.Log(item.GetComponentInChildren<ItemInfo>().ItemName + " was added");
                itemAdd = true;
                exportData.newData = true;
                break;
            }
        }

        if (!itemAdd)
        {
            Debug.Log("inventory Full");
        }
    }

    public void UpgradeItems(GameObject item)
    {
        inventory[0] = item;
    }

    public bool CheckItemInInventory(GameObject gamObj, int index)
    {
        if (inventory[index] != null && 
            inventory[index].GetComponentInChildren<ItemInfo>().gamObj == gamObj)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
