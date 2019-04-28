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

namespace PotAndRouge.GameSystem.CannonBall
{
    public class CannonBall : SerializedMonoBehaviour
    {
        [Title("Required")]
        [OdinSerialize, Required] Profile.SystemProfile SystemProfile { get; set; }

        [Title("Settings")]
        [OdinSerialize] int DestroyTriggerCount { get; set; } = 5;
        [OdinSerialize, ReadOnly] int WallHitCount { get; set; }

        void OnEnemyHit(GameObject enemy)
        {
            Destroy(enemy);
        }

        void OnTrigger()
        {
            Destroy(gameObject);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer(SystemProfile.EnemyLayerName))
            {
                OnEnemyHit(collision.gameObject);
            }

            if (collision.gameObject.layer == LayerMask.NameToLayer(SystemProfile.WallLayerName))
            {
                WallHitCount++;
            }
        }

        private void Update()
        {
            if (WallHitCount >= DestroyTriggerCount) OnTrigger();
        }
    }
}