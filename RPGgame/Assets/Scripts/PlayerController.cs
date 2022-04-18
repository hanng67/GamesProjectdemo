using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _theRB;

    [SerializeField]
    private float _moveSpeed;

    [SerializeField]
    private Animator _myAnim;

    public string areaTransistionName;

    public static PlayerController instance;

    private Vector3 _bottomLeftLimit;
    private Vector3 _topRightLimit;

    public bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            if(instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        if (canMove)
        {
            _theRB.velocity = new Vector2(horizontal, vertical) * _moveSpeed;
        }
        else
        {
            _theRB.velocity = Vector2.zero;
        }

        _myAnim.SetFloat("moveX", _theRB.velocity.x);
        _myAnim.SetFloat("moveY", _theRB.velocity.y);

        if ((horizontal == 1) || (horizontal == -1) || (vertical == 1) || (vertical == -1))
        {
            if (canMove)
            {
                _myAnim.SetFloat("lastMoveX", horizontal);
                _myAnim.SetFloat("lastMoveY", vertical);
            }
        }

        float boundX = Mathf.Clamp(transform.position.x, _bottomLeftLimit.x, _topRightLimit.x);
        float boundY = Mathf.Clamp(transform.position.y, _bottomLeftLimit.y, _topRightLimit.y);
        transform.position = new Vector3(boundX, boundY, transform.position.z);
    }

    public void SetBound(Vector3 bottomLeft, Vector3 topRight)
    {
        _bottomLeftLimit = bottomLeft + new Vector3(0.5f, 1f, 0f);
        _topRightLimit = topRight + new Vector3(-0.5f, -1f, 0f);
    }
}
