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

namespace PotAndRouge.UI
{
    public class Fading : SerializedMonoBehaviour
    {
        [Title("Settings")]
        [OdinSerialize] float FadeDuration { get; set; } = 1f;

        Image Image { get; set; }
        float TimeElapsed { get; set; }

        private void Awake()
        {
            Image = GetComponent<Image>();
            TimeElapsed = 0f;
        }

        private void OnEnable()
        {
            StartCoroutine(FadeIn(FadeDuration));
        }

        IEnumerator FadeIn(float duration)
        {
            while (true)
            {
                if (TimeElapsed > duration) yield break;
                TimeElapsed += Time.deltaTime;
                var color = Image.color;
                color.a = TimeElapsed / duration;
                Image.color = color;
                yield return null;
            }
        }
    }
}