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

namespace PotAndRouge.GameSystem.Player
{
    public class Movable : SerializedMonoBehaviour
    {
        [Title("Required")]
        [OdinSerialize] DB.PlayerInfo PlayerInfo { get; set; }

        [Title("Settings")]
        [OdinSerialize] float MinY { get; set; } = -10f;
        [OdinSerialize] float MaxY { get; set; } = 10f;
        [OdinSerialize] float Speed { get; set; } = 0.1f;

        float InitialY { get; set; }

        private void Awake()
        {
            InitialY = transform.position.y;
        }

        private void FixedUpdate()
        {
            var deltaY = transform.position.y - InitialY;

            if (Input.GetKey(PlayerInfo.KeyConfig.UpKey))
            {
                var position = transform.position;

                if (deltaY + Speed <= MaxY)
                {
                    position.y += Speed;
                }
                else
                {
                    position.y = MaxY;
                }

                transform.position = position;
            }

            if (Input.GetKey(PlayerInfo.KeyConfig.DownKey))
            {
                var position = transform.position;

                if (deltaY - Speed > MinY)
                {
                    position.y -= Speed;
                }
                else
                {
                    position.y = MinY;
                }

                transform.position = position;
            }
        }
    }
}