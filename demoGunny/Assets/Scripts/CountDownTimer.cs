using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDownTimer : MonoBehaviour
{
    public float TimeTurnPlay = 5.0f;
    float _timeRemain;
    public bool CountDownTime;
    // Start is called before the first frame update
    void Start()
    {
        _timeRemain = TimeTurnPlay;
        CountDownTime = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (CountDownTime)
        {
            UpdateTimeRemain(ref _timeRemain);
            UpdateInfoTimeToText(_timeRemain);
        }
    }

    void UpdateTimeRemain(ref float timeRemain)
    {
        if(timeRemain > 0)
        {
            timeRemain -= Time.deltaTime;
        }
        else
        {
            timeRemain = 0;
            CountDownTime = false;
        }
    }

    void UpdateInfoTimeToText(float time)
    {
        Debug.Log(time);
    }
}
