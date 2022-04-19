using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{
    [SerializeField]
    private string _areaToLoad;

    [SerializeField]
    private string _areaTransitionName;

    [SerializeField]
    private AreaEntrance _areaEntrance;

    [SerializeField]
    private float _waitToLoad;

    private bool _shouldLoadAfterFade;

    // Start is called before the first frame update
    void Start()
    {
        _areaEntrance.areaEntranceName = _areaTransitionName;
    }

    // Update is called once per frame
    void Update()
    {
        if (_shouldLoadAfterFade)
        {
            _waitToLoad -= Time.deltaTime;
            if(_waitToLoad <= 0)
            {
                _shouldLoadAfterFade = false;
                SceneManager.LoadScene(_areaToLoad);
            }
        }   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _shouldLoadAfterFade = true;
            GameManager.instance.fadingBetweenAreas = true;
            UIFade.instance.FadeToBlack();

            PlayerController.instance.areaTransistionName = _areaTransitionName;
        }
    }
}
