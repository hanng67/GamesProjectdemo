using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeButton : MonoBehaviour
{
    [SerializeField]
    private bool _physical;

    private GameObject _hero;

    // Start is called before the first frame update
    void Start()
    {
        string temp = gameObject.name;
        _hero = GameObject.FindGameObjectWithTag("Hero");
        gameObject.GetComponent<Button>().onClick.AddListener(() => AttachCallBack(temp));
    }

    private void AttachCallBack(string btn)
    {
        if (btn.CompareTo("MeleeBtn") == 0)
        {
            _hero.GetComponent<FighterAction>().SelectAttack("melee");
        }
        else if(btn.CompareTo("RangeBtn") == 0){
            _hero.GetComponent<FighterAction>().SelectAttack("range");
        }else
        {
            _hero.GetComponent<FighterAction>().SelectAttack("run");
        }
    }
}
