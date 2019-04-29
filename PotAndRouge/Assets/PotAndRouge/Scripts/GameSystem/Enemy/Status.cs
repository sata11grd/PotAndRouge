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

namespace PotAndRouge.GameSystem.Enemy
{
    public class Status : SerializedMonoBehaviour
    {
        [OdinSerialize] public uint Score { get; private set; } = 1000;
    }
}