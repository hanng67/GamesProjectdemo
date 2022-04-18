using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FighterStats : MonoBehaviour, IComparable
{
    [SerializeField]
    private float speed;

    [HideInInspector]
    public int nextActTurn;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void CalculateNextTurn(int currentTurn)
    {
        nextActTurn = currentTurn + Mathf.CeilToInt(100f / speed);
    }

    public int CompareTo(object otherStats)
    {
        int nex = nextActTurn.CompareTo(((FighterStats)otherStats).nextActTurn);
        return nex;
    }
}
