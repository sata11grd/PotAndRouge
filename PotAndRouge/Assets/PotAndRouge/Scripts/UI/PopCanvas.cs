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
    public class PopCanvas : SerializedMonoBehaviour
    {
        public enum POP_TYPE
        {
            Normal,
            Surprized
        }

        [Title("UI Reference")]
        [OdinSerialize] Text Text { get; set; }
        [OdinSerialize] Image NormalBackground { get; set; }
        [OdinSerialize] Image FlippedNormalBackground { get; set; }
        [OdinSerialize] Image SurprisedBackground { get; set; }
        [OdinSerialize] Image FlippedSurprisedBackground { get; set; }

        [Title("Settings")]
        [OdinSerialize] bool Flipped { get; set; }
        [OdinSerialize] Vector3 TargetScale { get; set; }
        [OdinSerialize] float Duration { get; set; } = 1f;
        [OdinSerialize] float TransitionTime { get; set; } = 0.3f;
        [OdinSerialize] float FloatingSpeed { get; set; } = 100f;

        [Title("Read Only")]
        [OdinSerialize, ReadOnly] POP_TYPE PopType { get; set; }
        [OdinSerialize, ReadOnly] Image BackgroundImage { get; set; }

        float TimeElapsed { get; set; }
        Vector3 InitialScale { get; set; }
        Vector3 InitialPosition { get; set; }
        RectTransform RectTransform { get; set; }

        Vector3 Lerp(Vector3 a, Vector3 b, float t)
        {
            var vec = Vector3.zero;
            vec.x = Mathf.Lerp(a.x, b.x, t);
            vec.y = Mathf.Lerp(a.y, b.y, t);
            vec.z = Mathf.Lerp(a.z, b.z, t);
            return vec;
        }

        public void ChangePopType(POP_TYPE target)
        {
            PopType = target;
        }

        public void ChangeText(string text)
        {
            Text.text = text;
        }

        private void Awake()
        {
            RectTransform = GetComponent<RectTransform>();
        }

        private void OnEnable()
        {
            TimeElapsed = 0f;
            InitialScale = RectTransform.localScale;
            InitialPosition = RectTransform.position;

            switch (PopType)
            {
                case POP_TYPE.Normal:
                    if (Flipped)
                    {
                        BackgroundImage = FlippedNormalBackground;
                    }
                    else
                    {
                        BackgroundImage = NormalBackground;
                    }
                    break;
                case POP_TYPE.Surprized:
                    if (Flipped)
                    {
                        BackgroundImage = FlippedSurprisedBackground;
                    }
                    else
                    {
                        BackgroundImage = SurprisedBackground;
                    }
                    break;
            }

            BackgroundImage.gameObject.SetActive(true);
        }

        private void OnDisable()
        {
            RectTransform.localScale = InitialScale;
            RectTransform.position = InitialPosition;
        }

        private void Update()
        {
            TimeElapsed += Time.deltaTime;

            if (TimeElapsed <= TransitionTime)
            {
                RectTransform.localScale = Lerp(InitialScale, TargetScale, TimeElapsed / TransitionTime);

                var color = BackgroundImage.color;
                color.a = TimeElapsed / TransitionTime;
                BackgroundImage.color = color;

                color = Text.color;
                color.a = TimeElapsed / TransitionTime;
                Text.color = color;
            }
            else if (TimeElapsed <= TransitionTime + Duration)
            {

            }
            else if (TimeElapsed <= TransitionTime + Duration + TransitionTime)
            {
                var t = (TimeElapsed - TransitionTime - Duration) / TransitionTime;
                RectTransform.position += new Vector3(0f, FloatingSpeed * Time.deltaTime, 0f);

                var color = BackgroundImage.color;
                color.a = 1f - t;
                BackgroundImage.color = color;

                color = Text.color;
                color.a = 1f - t;
                Text.color = color;
            }
            else
            {
                BackgroundImage.gameObject.SetActive(false);
                gameObject.SetActive(false);
            }
        }
    }
}