using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssentialLoader : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;

    [SerializeField]
    private GameObject _UICanvasFade;

    [SerializeField]
    private GameObject _gameMan;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerController.instance == null)
        {
            PlayerController clone = Instantiate(_player).GetComponent<PlayerController>();
            PlayerController.instance = clone;
        }

        if (UIFade.instance == null)
        {
            UIFade.instance = Instantiate(_UICanvasFade).GetComponent<UIFade>();
        }

        if(GameManager.instance == null)
        {
            Instantiate(_gameMan);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
