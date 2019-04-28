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

namespace PotAndRouge.DB
{
    [CreateAssetMenu(fileName = "PlayerInfo", menuName = "PotAndRouge/DB/PlayerInfo")]
    public class PlayerInfo : SerializedScriptableObject
    {
        [OdinSerialize] public string ID { get; set; }
        [OdinSerialize] public string Name { get; set; }
    }
}