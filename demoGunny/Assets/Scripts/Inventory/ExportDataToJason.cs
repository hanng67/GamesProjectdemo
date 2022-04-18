using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;

public class ExportDataToJason : MonoBehaviour
{
    // Start is called before the first frame update
    public ItemInfomation itemInfo;
    public bool newData;
    Inventory inventory;
    string saveFile;
    public void Start()
    {
        // Application.persistentDataPath = C:\Users\tanta\AppData\LocalLow\DefaultCompany\demoExportDataToJason
        //saveFile = Application.persistentDataPath + "/gamSetting.json";
        saveFile = "D:/Unity/demoGunny/Assets/DataExport" + "/gamSetting.txt";
        itemInfo.Info = new Infomation[5];
        inventory = gameObject.GetComponent<Inventory>();
    }

    public void Update()
    {
        GetInfo(inventory);
        if (newData)
        {
            WriteDataToJsonFile(itemInfo);
            newData = false;
        }
    }

    public void GetInfo(Inventory inventory)
    {
        for (int i = 0; i < 5; i++)
        {
            if(inventory.inventory[i] != null)
            {
                //itemInfo.Info[i] = inventory.inventory[i].GetComponentInChildren<ItemInfo>();
                itemInfo.Info[i].gamObj = inventory.inventory[i].GetComponentInChildren<ItemInfo>().gamObj;
                itemInfo.Info[i].ItemType = inventory.inventory[i].GetComponentInChildren<ItemInfo>().ItemType;
                itemInfo.Info[i].ItemLevel = inventory.inventory[i].GetComponentInChildren<ItemInfo>().ItemLevel;
                itemInfo.Info[i].ItemName = inventory.inventory[i].GetComponentInChildren<ItemInfo>().ItemName;
                itemInfo.Info[i].ItemDamage = inventory.inventory[i].GetComponentInChildren<ItemInfo>().ItemDamage;
                itemInfo.Info[i].ItemWeight = inventory.inventory[i].GetComponentInChildren<ItemInfo>().ItemWeight;
            }
        }
    }

    public string ExportDataToJSon(ItemInfomation itemsData)
    {
        return JsonUtility.ToJson(itemsData, true);
    }

    public void WriteDataToJsonFile(ItemInfomation itemsData)
    {
        // Serialize the object into JSON and save string.
        string jsonString = JsonUtility.ToJson(itemsData, true);
        //Debug.Log(jsonString);

        // Write JSON to file.
        File.WriteAllText(saveFile, jsonString);
    }

    public void ReadDataFromJsonFile(ref ItemInfomation itemsData)
    {
        if (File.Exists(saveFile))
        {
            // Read the entire file and save its contents.
            string dataContents = File.ReadAllText(saveFile);
            //Debug.Log(dataContents);

            // Deserialize the JSON data 
            //  into a pattern matching the GameData class.
            itemsData = JsonUtility.FromJson<ItemInfomation>(dataContents);
        }
    }

}

[Serializable]
public struct ItemInfomation
{
    public Infomation[] Info;
}

[Serializable]
public struct Infomation
{
    public GameObject gamObj;
    public string ItemName;
    public string ItemType;
    public string ItemLevel;
    public float ItemDamage;
    public float ItemWeight;
}
class abc : ItemInfo
{
}
