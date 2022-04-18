using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssentialLoader : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;

    [SerializeField]
    private GameObject _UICanvasFade;

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
            //Instantiate(_UICanvasFade);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
