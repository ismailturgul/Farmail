using System;
using System.IO.Pipes;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace World_Time
{
    [RequireComponent(typeof(Light2D))]
    public class World_Light : MonoBehaviour
    {
       private Light2D light2d;

        [SerializeField]
        private Worlds_Time world_Time;

        [SerializeField]
        private Gradient gradient;

        private void Awake()
        {
            light2d = GetComponent<Light2D>();
            world_Time.WorldTimeChanged += OnWorldTimeChanged;
        }

        private void OnDestroy()
        {
            world_Time.WorldTimeChanged -= OnWorldTimeChanged;

        }

        private void OnWorldTimeChanged(object sender, TimeSpan newTime)
        {
            light2d.color = gradient.Evaluate(PercentOfDay(newTime));
        }

        private float PercentOfDay(TimeSpan timeSpan)
        {
            return (float)timeSpan.TotalMinutes % World_Time_Constats.MinutsInDay / World_Time_Constats.MinutsInDay;
        }
    }
}

