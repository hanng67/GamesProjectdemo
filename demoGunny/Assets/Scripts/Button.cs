using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    public Sprite btnIdle;
    public Sprite btnHover;
    public Sprite btnClick;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BtnIdle()
    {
        gameObject.GetComponent<Image>().sprite = btnIdle;
    }

    public void BtnHover()
    {
        gameObject.GetComponent<Image>().sprite = btnHover;
    }

    public void BtnClick()
    {
        gameObject.GetComponent<Image>().sprite = btnClick;
    }
}
