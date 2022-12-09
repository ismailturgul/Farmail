using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering.Universal;
using System;

public class Day_Time_Controller : MonoBehaviour
{
    const float seconds_In_day = 86400f;

    [SerializeField] Color night_Light_Color;
    [SerializeField] AnimationCurve night_Time_Curve;
    [SerializeField] Color day_Light_Color = Color.white;
            [SerializeField]
        private Gradient gradient;
    float time;
    [SerializeField] float time_Scale = 60f;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Light2D global_Lights;
    private int days;

    float Hours
    {
        get { return time / 3600f; }
    }
    float Minuts
    {
        get { return time % 3600f / 60f; }
    }

    private void Update()
    {
        time += Time.deltaTime * time_Scale;
        int hh = (int)Hours;
        int mm = (int)Minuts;

        text.text = hh.ToString("00") + ":" + mm.ToString("00");
        float v = night_Time_Curve.Evaluate(Hours);
        Color c = Color.Lerp(day_Light_Color, night_Light_Color, v);
        global_Lights.color = c;
        if(time > seconds_In_day)
        {
            Next_Day();
        }
    }

    private void Next_Day()
    {
        time = 0;
        days += 1;
    }
}
