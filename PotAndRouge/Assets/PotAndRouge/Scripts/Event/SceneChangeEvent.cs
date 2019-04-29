using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace PotAndRouge.Event
{
    public class SceneChangeEvent : EventBase
    {
        [Title("Settings")]
        [OdinSerialize] string m_NextSceneName;
        [OdinSerialize] bool Fading { get; set; } = true;

        public override void Invoke()
        {
            base.Invoke();

#if UNITY_EDITOR
            if (m_NextSceneName == null) Debug.Log("Next scene name is null.");
#endif

            if (Fading) FindObjectOfType<GUI.FadeManager>().FadeOut();
            UnityEngine.SceneManagement.SceneManager.LoadScene(m_NextSceneName);
            if (Fading) FindObjectOfType<GUI.FadeManager>().FadeIn();
        }
    }
}
