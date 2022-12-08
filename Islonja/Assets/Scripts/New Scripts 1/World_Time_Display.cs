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
        private TMP_Text world_text;

        private void Awake()
        {
            world_text = GetComponent<TMP_Text>();
            world_Time.WorldTimeChanged += OnWorldTimeChanged;
        }

        private void OnDestroy()
        {
            world_Time.WorldTimeChanged -= OnWorldTimeChanged;
        }

        private void OnWorldTimeChanged(object sender, TimeSpan newTime)
        {
            world_text.SetText(newTime.ToString(@"hh\:mm"));

        }
    }

}
