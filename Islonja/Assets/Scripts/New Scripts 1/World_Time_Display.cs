using System;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace World_Time
{
    [RequireComponent(typeof(TMP_Text))]

    public class World_Time_Display : MonoBehaviour
    {
        [SerializeField]
        private Worlds_Time world_Time;
        string[] day_Of_The_Weeks = { "Monday", "tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"};

        private TMP_Text world_text;
        private TMP_Text day_text;

        private void Awake()
        {
            world_text = GetComponent<TMP_Text>();
            day_text= GetComponent<TMP_Text>();
            world_Time.WorldTimeChanged += OnWorldTimeChanged;
        }

        private void OnDestroy()
        {
            world_Time.WorldTimeChanged -= OnWorldTimeChanged;
        }

        private void OnWorldTimeChanged(object sender, TimeSpan newTime)
        {
            world_text.SetText(newTime.ToString(@"d.Tag\hh\:mm"));
            StartCoroutine(AddDay());
        }

        private IEnumerator AddDay()
        {
            yield return new WaitForSeconds(10f);
            
            for(int i = 0; i < day_Of_The_Weeks.Length; i++)
            {
                day_text.SetText(day_Of_The_Weeks[i]);
            }
        }
    }

}
