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

namespace PotAndRouge.Cache
{
    public class GameCache : SerializedMonoBehaviour
    {
        [OdinSerialize] public Dictionary<DB.PlayerInfo, uint> Scores { protected get; set; } = new Dictionary<DB.PlayerInfo, uint>();

        public void IncreaseScore(DB.PlayerInfo playerInfo, uint score)
        {
            if (!Scores.ContainsKey(playerInfo)) throw new System.Exception("PlayerInfo could not been found.");
            Scores[playerInfo] += score;
        }
    }
}