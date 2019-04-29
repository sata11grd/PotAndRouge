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

namespace PotAndRouge.Profile
{
    [CreateAssetMenu(fileName = "SystemProfile", menuName = "PotAndRouge/Profile/SystemProfile")]
    public class SystemProfile : SerializedScriptableObject
    {
        [OdinSerialize] public string PlayerLayerName { get; private set; } = "Player";
        [OdinSerialize] public string WallLayerName { get; private set; } = "Wall";
        [OdinSerialize] public string EnemyLayerName { get; private set; } = "Enemy";
    }
}