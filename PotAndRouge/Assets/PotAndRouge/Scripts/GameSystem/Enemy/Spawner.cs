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
    public class Spawner : SerializedMonoBehaviour
    {
        [OdinSerialize] float Interval { get; set; } = 2f;
        [OdinSerialize] List<GameObject> Spawnables { get; set; } = new List<GameObject>();

        List<Transform> SpawnPoints { get; set; } = new List<Transform>();

        float m_TimeElapsed { get; set; }

        void Spawn()
        {
            int index = Random.Range(0, Spawnables.Count);
            var enemy = Instantiate(Spawnables[index]);
            enemy.transform.parent = transform;
            enemy.transform.position = SpawnPoints[Random.Range(0, SpawnPoints.Count)].position;
        }

        private void Awake()
        {
            foreach(Transform child in transform)
            {
                SpawnPoints.Add(child);
            }
        }

        private void Update()
        {
            m_TimeElapsed += Time.deltaTime;

            if (m_TimeElapsed >= Interval)
            {
                Spawn();
                m_TimeElapsed = 0f;
            }
        }
    }
}