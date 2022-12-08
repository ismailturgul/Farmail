using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace World_Time
{
    public class Worlds_Time : MonoBehaviour
    {
      
        public event EventHandler<TimeSpan> WorldTimeChanged;
        [SerializeField]
        private float day_Length; // in sec.
        
        private TimeSpan current_Time;

        private float Minute_length => day_Length / World_Time_Constats.MinutsInDay;  //declares a min.

        private void Start()
        {
            StartCoroutine(AddMinute());
        }

        private IEnumerator AddMinute()
        {
            current_Time += TimeSpan.FromMinutes(1);
            WorldTimeChanged?.Invoke(this, current_Time);
            yield return new WaitForSeconds(Minute_length);
            StartCoroutine(AddMinute());
           
        }
    }
}