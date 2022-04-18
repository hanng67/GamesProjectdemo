using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackScript : MonoBehaviour
{
    public GameObject owner;

    [SerializeField]
    private string _animationName;

    [SerializeField]
    private bool _magicAttack;

    [SerializeField]
    private float _magicCost;

    [SerializeField]
    private float _minAttackMultiplier;

    [SerializeField]
    private float _maxAttackMultiplier;

    [SerializeField]
    private float _minDefendMultiplier;

    [SerializeField]
    private float _maxDefendMultiplier;

    private FighterStats _attackerStats;
    private FighterStats _targetStats;
    private float _damage = 0.0f;

    private GameController gameCtr;

    private void Awake()
    {
        gameCtr = GameObject.Find("GameControllerObject").GetComponent<GameController>();
    }

    public void Attack(GameObject victim)
    {
        _attackerStats = owner.GetComponent<FighterStats>();
        _targetStats = victim.GetComponent<FighterStats>();

        bool flagMagicAttack = _attackerStats.GetFlagMagicAttack();
        if (_attackerStats.Magic >= _magicCost)
        {
            float multiplier = Random.Range(_minAttackMultiplier, _maxAttackMultiplier);
            _attackerStats.UpdateMagicFill(_magicCost);
            if (_magicCost > _attackerStats.Magic)
            {
                _attackerStats.SetFlagMagicAttack(false);
            }

            _damage = multiplier * _attackerStats.MeleeDamage;

            if (_magicAttack)
            {
                _damage = multiplier * _attackerStats.RangeDamage;
            }

            float defendMultiplier = Random.Range(_minDefendMultiplier, _maxDefendMultiplier);
            _damage = Mathf.Max(0, (_damage - (defendMultiplier * _targetStats.Defend)));
            owner.GetComponent<Animator>().Play(_animationName);
            _targetStats.ReceiveDamage(Mathf.CeilToInt(_damage)); 
            gameCtr.SetActiveBattleMenu(false);
        }
    }
}
