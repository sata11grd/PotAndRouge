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

namespace PotAndRouge.Config
{
    [CreateAssetMenu(fileName = "KeyConfig", menuName = "PotAndRouge/Config/KeyConfig")]
    public class KeyConfig : SerializedScriptableObject
    {
        [OdinSerialize] public KeyCode ShotKey { get; set; }
        [OdinSerialize] public KeyCode UpKey { get; set; }
        [OdinSerialize] public KeyCode DownKey { get; set; }
    }
}