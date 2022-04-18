using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public bool isReward;
    public GameObject panel;

    private List<FighterStats> _fighterStats;

    // Start is called before the first frame update
    void Awake()
    {
        panel.SetActive(false);

        _fighterStats = new List<FighterStats>();
        //GameObject player = GameObject.FindGameObjectWithTag("Player");
        //FighterStats currentPlayerStats = player.GetComponent<FighterStats>();
        //currentPlayerStats.CalculateNextTurn(0);
        //_fighterStats.Add(currentPlayerStats);

        //GameObject monster = GameObject.FindGameObjectWithTag("Monster");
        //FighterStats currentMonsterStats = monster.GetComponent<FighterStats>();
        //currentMonsterStats.CalculateNextTurn(0);
        //_fighterStats.Add(currentMonsterStats);

        //_fighterStats.Sort();
        //NextTurn();
    }

    // Update is called once per frame
    void Update()
    {
        if (isReward)
        {
            panel.SetActive(true);
            isReward = false;
        }
        
    }

    //public void NextTurn()
    //{
    //    FighterStats currentFighterStats = _fighterStats[0];
    //    _fighterStats.Remove(currentFighterStats);

    //    GameObject currentUnits = currentFighterStats.gameObject;
    //    currentFighterStats.CalculateNextTurn(currentFighterStats.nextActTurn);
    //    _fighterStats.Add(currentFighterStats);
    //    _fighterStats.Sort();
    //    Debug.Log("***************************");
    //    Debug.Log(currentUnits.tag);

    //    if (currentUnits.CompareTag("Player"))
    //    {
    //        currentUnits.GetComponent<Player>().isBeingAttack = true;
    //    }
    //    else
    //    {
    //        currentUnits.GetComponent<Monster>().isBeingAttack = true;
    //    }
    //}
}
