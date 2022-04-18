using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStats : MonoBehaviour
{
    public string charName;
    public int playerLevel = 1;
    public int currentExp;
    public int[] expToNextLevel;
    private int _maxLevel = 100;
    private int _baseEXP = 1000;

    public int currentHP;
    public int maxHP = 100;
    public int currentMP;
    public int maxMP = 30;
    public int[] mpLvlBonus;
    public int strengh;
    public int defence;
    public int wpnPwr;
    public int armrPwr;
    public string equippedWpn;
    public string equippedArmr;

    public Sprite charImage;

    // Start is called before the first frame update
    void Start()
    {
        expToNextLevel = new int[_maxLevel];
        mpLvlBonus = new int[_maxLevel];
        expToNextLevel[1] = _baseEXP;
        for (int i=2; i < _maxLevel; i++)
        {
            expToNextLevel[i] = Mathf.FloorToInt(expToNextLevel[i - 1] * 1.05f);

            if(i%2 == 0)
            {
                mpLvlBonus[i] = i * 10;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddExp(int expToAdd)
    {
        currentExp += expToAdd;

        if (playerLevel < _maxLevel)
        {
            if (currentExp > expToNextLevel[playerLevel])
            {
                currentExp -= expToNextLevel[playerLevel];
                playerLevel++;
            }

            //determine whether to add to str of def based on odd or even
            if (playerLevel % 2 == 0)
            {
                strengh++;
            }
            else
            {
                defence++;
            }

            maxHP = Mathf.FloorToInt(maxHP * 1.05f);
            currentHP = maxHP;

            maxMP += mpLvlBonus[playerLevel];
            currentMP = maxMP;
        }

        if(playerLevel >= _maxLevel)
        {
            currentExp = 0;
        }
    }
}
