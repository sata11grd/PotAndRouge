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

namespace PotAndRouge.GameSystem.Doll
{
    public class PlayerKiller : SerializedMonoBehaviour
    {
        [Title("Required")]
        [OdinSerialize] Profile.SystemProfile SystemProfile { get; set; }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer(SystemProfile.PlayerLayerName))
            {
                var manager = FindObjectOfType<GameManager>();
                if (manager == null) throw new System.Exception("GameManager could not be found.");
                manager.Terminate();
            }
        }
    }
}