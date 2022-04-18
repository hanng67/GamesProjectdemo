using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomItems : MonoBehaviour
{
    public GameObject[] RandomItemList = new GameObject[5];
    public GameObject Item;
    private float randomTime;
    public bool isRandomTimeOut;
    private int count;
    private float timeUpdate;
    // Start is called before the first frame update
    void Start()
    {
        randomTime = 10.0f;
        isRandomTimeOut = false;
        timeUpdate = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent.gameObject.activeSelf && (!isRandomTimeOut))
        {
            if(Time.time > timeUpdate + 0.1f)
            {
                timeUpdate = Time.time;
                count++;
            }

            randomTime -= 0.05f;
            if (randomTime < 0)
            {
                isRandomTimeOut = true;
            }
            Item = RandomItemList[count];
            gameObject.GetComponentInChildren<Image>().sprite = Item.GetComponent<SpriteRenderer>().sprite;
            if(count == RandomItemList.Length - 1)
            {
                count = 0;
            }
        }
        else
        {
            randomTime = 1.0f;
        }
    }
}
