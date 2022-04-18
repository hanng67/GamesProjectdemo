using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private List<FighterStats> _fighterStats;

    [SerializeField]
    private GameObject _battleMenu;

    public Text BattleText;

    private void Start()
    {
        _fighterStats = new List<FighterStats>();
        GameObject hero = GameObject.FindGameObjectWithTag("Hero");
        FighterStats currentHeroStats = hero.GetComponent<FighterStats>();
        currentHeroStats.CalculateNextTurn(0);
        _fighterStats.Add(currentHeroStats);

        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        FighterStats currentEnemyStats = enemy.GetComponent<FighterStats>();
        currentEnemyStats.CalculateNextTurn(0);
        _fighterStats.Add(currentEnemyStats);

        _fighterStats.Sort();
        SetActiveBattleMenu(false);

        NextTurn();
    }

    public void NextTurn()
    {
        BattleText.gameObject.SetActive(false);
        FighterStats currentFighterStats = _fighterStats[0];
        _fighterStats.Remove(currentFighterStats);
        if (!currentFighterStats.GetDead())
        {
            GameObject currentUnit = currentFighterStats.gameObject;
            currentFighterStats.CalculateNextTurn(currentFighterStats.nextActTurn);
            _fighterStats.Add(currentFighterStats);
            _fighterStats.Sort();

            if (currentUnit.CompareTag("Hero"))
            {
                SetActiveBattleMenu(true);
            }
            else
            {
                bool flagMagicAttack = currentUnit.GetComponent<FighterStats>().GetFlagMagicAttack();
                string attackType;
                if (flagMagicAttack)
                {
                    attackType = Random.Range(0, 2) == 1 ? "melee" : "range";
                }
                else
                {
                    attackType = "melee";
                }
                currentUnit.GetComponent<FighterAction>().SelectAttack(attackType);
            }
        }
        else
        {
            NextTurn();
        }

    }

    public void SetActiveBattleMenu(bool value)
    {
        this._battleMenu.SetActive(value);
    }
}
