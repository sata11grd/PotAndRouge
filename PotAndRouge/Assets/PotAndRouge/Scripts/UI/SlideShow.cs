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
    public class SlideShow : SerializedMonoBehaviour
    {
        [OdinSerialize] float ShowingDuration { get; set; } = 3f;
        [OdinSerialize] KeyCode SkipKey { get; set; } = KeyCode.Space;
        [OdinSerialize] string NextScene { get; set; } = "Game";
        [OdinSerialize] float FadeDuration { get; set; } = 1f;

        List<Image> Images { get; set; } = new List<Image>();
        float TimeElapsed { get; set; }

        void OnFinished()
        {
            var manager = FindObjectOfType<GUI.FadeManager>();
            manager.LoadScene(FadeDuration, NextScene);
        }

        private void Awake()
        {
            TimeElapsed = 0f;
            foreach(Transform child in transform)
            {
                var image = child.gameObject.GetComponent<Image>();
                Images.Add(image);
            }
        }

        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(SkipKey))
            {
                OnFinished();
                return;
            }

            TimeElapsed += Time.deltaTime;

            int index = (int)(TimeElapsed / ShowingDuration);
            if (index >= Images.Count)
            {
                if (UnityEngine.Input.anyKeyDown) OnFinished();
                return;
            }

            Images.ForEach(image => image.gameObject.SetActive(false));
            Images[index].gameObject.SetActive(true);
        }
    }
}