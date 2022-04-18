using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Tilemap _theMap;

    private Transform _target;

    private Vector3 _bottomLeftLimit;
    private Vector3 _topRightLimit;

    private float _halfHeigh;
    private float _halfWidth;

    // Start is called before the first frame update
    void Start()
    {
        _target = FindObjectOfType<PlayerController>().transform;

        _halfHeigh = Camera.main.orthographicSize;
        _halfWidth = _halfHeigh * Camera.main.aspect;

        _bottomLeftLimit = _theMap.localBounds.min + new Vector3(_halfWidth, _halfHeigh, 0f);
        _topRightLimit = _theMap.localBounds.max + new Vector3(-_halfWidth, -_halfHeigh, 0f);

        PlayerController.instance.SetBound(_theMap.localBounds.min, _theMap.localBounds.max);
    }

    // LateUpdate is called once per frame after Update()
    void LateUpdate()
    {
        transform.position = new Vector3(_target.position.x, _target.position.y, transform.position.z);

        // keep the camera inside the bound
        float boundX = Mathf.Clamp(transform.position.x, _bottomLeftLimit.x, _topRightLimit.x);
        float boundY = Mathf.Clamp(transform.position.y, _bottomLeftLimit.y, _topRightLimit.y);
        transform.position = new Vector3(boundX, boundY, transform.position.z);
    }
}
