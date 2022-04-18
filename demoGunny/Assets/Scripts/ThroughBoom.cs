using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThroughBoom : MonoBehaviour
{
    public GameObject Boom;
    float _radius;
    private Vector2 _directionAttack;
    private Vector2 _shotPoint;
    private float _power;

    private float spaceBetweenPoints = 0.0005f;
    private LineRenderer _lr;
    private Vector2 _endShotPoint;

    // Start is called before the first frame update
    void Start()
    {
        _radius = 1.5f;
        _lr = gameObject.GetComponent<LineRenderer>();
        _lr.enabled = true;
    }

    private void Update()
    {
        _endShotPoint = CalculatePointPosition(10 * spaceBetweenPoints);
        _lr.SetPosition(0, _shotPoint);
        _lr.SetPosition(1, _endShotPoint);
    }

    public void InstantiateBoomAtPositionAttack(int attackPower)
    {
        Boom.GetComponent<BoomControl>().ObjAttackTag = gameObject.tag;
        Vector2 posAttack = transform.parent.transform.position;

        GameObject boom = Instantiate(Boom, _shotPoint, Quaternion.identity) as GameObject;
        boom.GetComponent<Rigidbody2D>().AddForce(_directionAttack * attackPower);
    }

    public void CalculateDirectionAttack(int angle, int power)
    {
        _power = power;
        Vector2 posAttack = transform.parent.transform.position;
        float rotaYObjPosAttack = transform.rotation.y;

        float radian = angle * Mathf.Deg2Rad;
        float posAngleAttackX = posAttack.x + Mathf.Cos(radian) * _radius;
        float posAngleAttackY = posAttack.y + Mathf.Sin(radian) * _radius;

        Vector2 posAngleAttack = new Vector2(posAngleAttackX, posAngleAttackY);
        _shotPoint = posAngleAttack;
        int directOfObj;
        if (rotaYObjPosAttack != 0)
        {
            directOfObj = -1;
        }
        else
        {
            directOfObj = 1;
        }
        Vector2 directionAttack = (posAngleAttack - posAttack).normalized;
        _directionAttack = new Vector2(directionAttack.x * directOfObj, directionAttack.y);

    }

    Vector2 CalculatePointPosition(float t)
    {
        // formular x = x0 + v0*t + 0.5*a*t^2
        Vector2 position = _shotPoint + (_directionAttack * t * 400) + (0.5f * Physics2D.gravity * t * t);
        return position;
    }
}
