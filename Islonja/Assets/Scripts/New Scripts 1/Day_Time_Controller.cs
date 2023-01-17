using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering.Universal;
using System;

public class Day_Time_Controller : MonoBehaviour
{
    const float seconds_In_day = 86400f;

    const float phaseLength = 900f; // 15 min. in seconds
    [SerializeField] Color night_Light_Color;
    [SerializeField] AnimationCurve night_Time_Curve;
    [SerializeField] Color day_Light_Color = Color.white;
    
    [SerializeField]
        private Gradient gradient;
    float time = 6f;


    [SerializeField] float time_Scale = 60f;
    [SerializeField] float startAtTime = 28800f; // in seconds
    
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Light2D global_Lights;
    private int days;

    List<TimeAgent> agents;

    private void Awake()
    {
        agents = new List<TimeAgent>();
    }
    private void Start()
    {
        time = startAtTime;
    }
    public void Subscribe(TimeAgent timeAgent)
    {
        agents.Add(timeAgent);
    }
    public void Unsubscribe(TimeAgent timeAgent)
    {
        agents.Remove(timeAgent);
    }

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
        TimeValueCalculation();
        DayLight();
        if (time > seconds_In_day)
        {
            Next_Day();
        }

        TimeAgents();
    }



    private void TimeValueCalculation()
    {
        int hh = (int)Hours;
        int mm = (int)Minuts;

        text.text = hh.ToString("00") + ":" + mm.ToString("00");
    }
    private void DayLight()
    {
        float v = night_Time_Curve.Evaluate(Hours);
        Color c = Color.Lerp(day_Light_Color, night_Light_Color, v);
        global_Lights.color = c;
    }

    int oldPhase = 0;
    private void TimeAgents()
    {
        int currentPhase = (int)(time / phaseLength);
        
        if (oldPhase != currentPhase)
        {
            oldPhase = currentPhase;

            for (int i = 0; i < agents.Count; i++)
            {

                agents[i].Invoke();
            }
        }
    }
    private void Next_Day()
    {
        time = 0;
        days += 1;
    }
}
