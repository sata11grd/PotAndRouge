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
        [OdinSerialize, Required] DB.PlayerInfo Holder { get; set; }
        [OdinSerialize, Required] Profile.SystemProfile SystemProfile { get; set; }

        [Title("Settings")]
        [OdinSerialize] int DestroyTriggerCount { get; set; } = 5;
        [OdinSerialize, ReadOnly] int WallHitCount { get; set; }
        [OdinSerialize] float Duration { get; set; } = 5f;
        [OdinSerialize] GameObject HitParticle { get; set; }
        [OdinSerialize] GameObject SubParticle { get; set; }

        float m_TimeElapsed;

        void OnEnemyHit(GameObject enemy)
        {
            var cache = FindObjectOfType<Cache.GameCache>();
            if (cache == null) throw new System.Exception("GameCache could not be found.");

            var status = enemy.GetComponent<Enemy.Status>();
            if (status == null) throw new System.Exception("Enemy status could not be found.");

            cache.IncreaseScore(Holder, status.Score);
            enemy.GetComponent<Enemy.GetHitHandler>().GetHit(HitParticle);
        }

        void OnTrigger()
        {
            Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer(SystemProfile.EnemyLayerName))
            {
                OnEnemyHit(collision.gameObject);
                return;
            }

            if (collision.gameObject.layer == LayerMask.NameToLayer(SystemProfile.WallLayerName))
            {
                WallHitCount++;
                return;
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer(SystemProfile.CannonBallLayerName))
            {
                var obj = Instantiate(SubParticle);
                obj.transform.position = transform.position;
            }
        }

        private void Update()
        {
            m_TimeElapsed += Time.deltaTime;
            if (WallHitCount >= DestroyTriggerCount || m_TimeElapsed >= Duration) OnTrigger();
        }
    }
}