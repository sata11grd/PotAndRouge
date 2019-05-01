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
    public class ScoreText : SerializedMonoBehaviour
    {
        [Title("Required")]
        [OdinSerialize, Required] Cache.GameCache GameCache { get; set; }

        [Title("Settings")]
        [OdinSerialize] DB.PlayerInfo PlayerInfo { get; set; }

        Text Text { get; set; }

        private void Awake()
        {
            Text = GetComponent<Text>();
        }

        private void Update()
        {
            uint score = GameCache.Scores[PlayerInfo];
            Text.text = score.ToString("N0");
        }
    }
}