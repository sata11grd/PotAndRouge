using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace PotAndRouge.Util
{
    public class Timer : SerializedMonoBehaviour
    {
        [Title("Settings")]
        [OdinSerialize] public float Duration { get; set; } = 120f;
        [OdinSerialize] UnityEvent OnTimeElapsed { get; set; } = new UnityEvent();

        [Title("State")]
        [OdinSerialize] public float RemainingDuration { get; set; } = 0f;

        private void OnEnable()
        {
            RemainingDuration = Duration;
        }

        private void Update()
        {
            RemainingDuration -= Time.deltaTime;

            if (RemainingDuration <= 0f)
            {
                RemainingDuration = 0f;
                OnTimeElapsed.Invoke();
                gameObject.SetActive(false);
            }
        }
    }
}