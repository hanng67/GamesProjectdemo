using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public CharStats[] playerStats;

    public bool gameMenuOpen, dialogActive, fadingBetweenAreas;

    public string[] itemsHeld;
    public int[] numberOfItems;
    public Item[] referenceItems;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameMenuOpen || dialogActive || fadingBetweenAreas)
        {
            PlayerController.instance.canMove = false;
        }
        else
        {
            PlayerController.instance.canMove = true;
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            AddItem("Iron Armor");
            AddItem("Leather Armor");

            RemoveItem("Health Potion");
            RemoveItem("Mana Potion");
        }
    }

    public Item GetItemDetails(string itemToGrab)
    {
        for (int i = 0; i < referenceItems.Length; i++)
        {
            if(referenceItems[i].itemName == itemToGrab)
            {
                return referenceItems[i];
            }
        }

        return null;
    }

    public void SortItems()
    {
        // Follow tutorial
        //bool itemAfterSpace = true;

        //while (itemAfterSpace)
        //{
        //    itemAfterSpace = false;
        //    for (int i = 0; i < itemsHeld.Length-1; i++)
        //    {
        //        if(itemsHeld[i] == "")
        //        {
        //            itemsHeld[i] = itemsHeld[i + 1];
        //            itemsHeld[i + 1] = "";

        //            numberOfItems[i] = numberOfItems[i + 1];
        //            numberOfItems[i + 1] = 0;

        //            if(itemsHeld[i] != "")
        //            {
        //                itemAfterSpace = true;
        //            }
        //        }
        //    }
        //}

        for (int i = 0; i < itemsHeld.Length-1; i++)
        {
            if (itemsHeld[i] != "") continue;

            for (int j = i+1; j < itemsHeld.Length; j++)
            {
                if (itemsHeld[j] == "") continue;

                SwapItems(i, j);
                break;
            }
        }
    }

    private void SwapItems(int firstIdx, int secondIdx)
    {
        itemsHeld[firstIdx] = itemsHeld[secondIdx];
        itemsHeld[secondIdx] = "";

        numberOfItems[firstIdx] = numberOfItems[secondIdx];
        numberOfItems[secondIdx] = 0;
    }

    public void AddItem(string itemToAdd)
    {
        int newItemPosition = 0;
        bool isFoundSpace = false;

        for (int i = 0; i < itemsHeld.Length; i++)
        {
            if((itemsHeld[i] == itemToAdd) || (itemsHeld[i] == ""))
            {
                newItemPosition = i;
                isFoundSpace = true;
                break;
            }
        }

        if (isFoundSpace)
        {
            bool isExist = false;
            for (int i = 0; i < referenceItems.Length; i++)
            {
                if(referenceItems[i].itemName == itemToAdd)
                {
                    isExist = true;
                    break;
                }
            }

            if (isExist)
            {
                itemsHeld[newItemPosition] = itemToAdd;
                numberOfItems[newItemPosition]++;
            }
            else
            {
                Debug.LogError(itemToAdd + " Does Not Exist!");
            }
        }

        GameMenu.instance.ShowItems();
    }

    public void RemoveItem(string itemToRemove)
    {
        int itemPosition = 0;
        bool isFoundItem = false;

        for (int i = 0; i < itemsHeld.Length; i++)
        {
            if(itemsHeld[i] == itemToRemove)
            {
                itemPosition = i;
                isFoundItem = true;
                break;
            }
        }

        if (isFoundItem)
        {
            numberOfItems[itemPosition]--;

            if(numberOfItems[itemPosition] <= 0)
            {
                itemsHeld[itemPosition] = "";
            }

            GameMenu.instance.ShowItems();
        }
        else
        {
            Debug.LogError("Couldn't Find " + itemToRemove);
        }
    }
}
