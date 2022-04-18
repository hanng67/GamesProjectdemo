using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FighterAction : MonoBehaviour
{
    private GameObject _hero;
    private GameObject _enemy;

    [SerializeField]
    private GameObject _meleePrefabs;

    [SerializeField]
    private GameObject _rangePrefabs;

    [SerializeField]
    private Sprite _faceIcon;

    // Start is called before the first frame update
    void Awake()
    {
        _hero = GameObject.FindGameObjectWithTag("Hero");
        _enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    public void SelectAttack(string btn)
    {
        GameObject victim = tag == "Hero" ? _enemy : _hero;
        if(btn.CompareTo("melee") == 0)
        {
            _meleePrefabs.GetComponent<AttackScript>().Attack(victim);
        }else if(btn.CompareTo("range") == 0)
        {
            _rangePrefabs.GetComponent<AttackScript>().Attack(victim);
        }
        else
        {
            Debug.Log("Run");
        }
    }
}
