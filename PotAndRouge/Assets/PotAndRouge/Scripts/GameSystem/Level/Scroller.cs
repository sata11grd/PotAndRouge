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

namespace PotAndRouge.GameSystem.Level
{
    public class Scroller : SerializedMonoBehaviour
    {
        [OdinSerialize] float Speed { get; set; } = 10f;

        private void Update()
        {
            var position = transform.position;
            position.y -= Speed * Time.deltaTime;
            transform.position = position;
        }
    }
}