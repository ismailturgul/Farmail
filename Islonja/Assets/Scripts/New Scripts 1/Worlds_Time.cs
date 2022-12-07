using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace World_Time
{
    public class Worlds_Time : MonoBehaviour
    {
        [SerializeField]
        private float day_Length; // in sec.

        private TimeSpan current_Time;
        private float Minute_length => day_Length / World_Time_Constats.MinutsInDay;

        private void Start()
        {
            StartCoroutine(AddMinute());
        }

        private IEnumerator AddMinute()
        {
            current_Time += TimeSpan.FromMinutes(1);
            yield return new WaitForSeconds(Minute_length);
            StartCoroutine(AddMinute());
        }
    }
}