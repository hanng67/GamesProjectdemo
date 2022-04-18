using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class FighterStats : MonoBehaviour, IComparable
{
    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private GameObject _healthFill;

    [SerializeField]
    private GameObject _magicFill;

    [Header("Stats")]
    public float Health;
    public float Magic;
    public float MeleeDamage;
    public float RangeDamage;
    public float Defend;
    public float Speed;
    public float Experience;

    private float _startHealth;
    private float _startMagic;

    [HideInInspector]
    public int nextActTurn;

    private bool _dead = false;
    private bool _isEnoughMagic = true;

    // Resize health and magic bar
    private Transform _healthTransform;
    private Transform _magicTransform;

    private Vector3 _healthScale;
    private Vector2 _magicScale;

    private float _xNewHealthScale;
    private float _xNewMagicScale;

    private GameController gameCtr;

    void Awake()
    {
        _healthTransform = _healthFill.GetComponent<RectTransform>();
        _healthScale = _healthFill.transform.localScale;

        _magicTransform = _magicFill.GetComponent<RectTransform>();
        _magicScale = _magicFill.transform.localScale;

        _startHealth = Health;
        _startMagic = Magic;

        gameCtr = GameObject.Find("GameControllerObject").GetComponent<GameController>();
    }

    public void ReceiveDamage(float damage)
    {
        Health -= damage;
        _animator.Play("Damage");

        // Set Damage text
        if(Health <= 0)
        {
            _dead = true;
            gameObject.tag = "Dead";
            Destroy(_healthFill);
            Destroy(gameObject);
        }
        else
        {
            _xNewHealthScale = _healthScale.x * (Health / _startHealth);
            _healthFill.transform.localScale = new Vector2(_xNewHealthScale, _healthScale.y);
        }

        if(damage > 0)
        {
            gameCtr.BattleText.gameObject.SetActive(true);
            gameCtr.BattleText.text = damage.ToString();
        }
        Invoke("ContinueGame", 1.5f);
    }

    public void UpdateMagicFill(float cost)
    {
        Magic -= cost;
        _xNewMagicScale = _magicScale.x * (Magic / _startMagic);
        _magicFill.transform.localScale = new Vector2(_xNewMagicScale, _magicScale.y);
    }

    public bool GetDead()
    {
        return _dead;
    }

    public void SetFlagMagicAttack(bool value)
    {
        _isEnoughMagic = value;
    }

    public bool GetFlagMagicAttack()
    {
        return _isEnoughMagic;
    }

    void ContinueGame()
    {
        gameCtr.NextTurn();
    }

    public void CalculateNextTurn(int currentTurn)
    {
        nextActTurn = currentTurn + Mathf.CeilToInt(100f / Speed);
    }

    public int CompareTo(object otherStats)
    {
        int nex = nextActTurn.CompareTo(((FighterStats)otherStats).nextActTurn);
        return nex;
    }
}
