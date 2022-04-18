using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFade : MonoBehaviour
{
    public static UIFade instance;

    [SerializeField]
    private Image _fadeScene;

    [SerializeField]
    private float _fadeSpeed;

    private bool _shouldFadeToBlack;
    private bool _shouldFadeFromBlack;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (_shouldFadeToBlack)
        {
            _fadeScene.color = new Color(_fadeScene.color.r, _fadeScene.color.g, _fadeScene.color.b, 
                                        Mathf.MoveTowards(_fadeScene.color.a, 1f, _fadeSpeed * Time.deltaTime));
            if(_fadeScene.color.a == 1f)
            {
                _shouldFadeToBlack = false;
            }
        }

        if (_shouldFadeFromBlack)
        {
            _fadeScene.color = new Color(_fadeScene.color.r, _fadeScene.color.g, _fadeScene.color.b,
                                        Mathf.MoveTowards(_fadeScene.color.a, 0f, _fadeSpeed * Time.deltaTime));
            if (_fadeScene.color.a == 0f)
            {
                _shouldFadeFromBlack = false;
            }
        }
    }

    public void FadeToBlack()
    {
        _shouldFadeToBlack = true;
        _shouldFadeFromBlack = false;
    }

    public void FadeFromBlack()
    {
        _shouldFadeToBlack = false;
        _shouldFadeFromBlack = true;
    }
}
