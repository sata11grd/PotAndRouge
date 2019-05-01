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
    public class TimeGage : SerializedMonoBehaviour
    {
        [OdinSerialize] Util.Timer Timer { get; set; }

        Image Image { get; set; }

        private void Awake()
        {
            Image = GetComponent<Image>();
        }

        private void Update()
        {
            if (Image.fillAmount == 0f) Image.gameObject.SetActive(false);
            Image.fillAmount = Timer.RemainingDuration / Timer.Duration;
        }
    }
}