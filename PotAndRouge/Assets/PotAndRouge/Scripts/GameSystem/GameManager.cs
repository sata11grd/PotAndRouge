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

namespace PotAndRouge.GameSystem
{
    public class GameManager : SerializedMonoBehaviour
    {
        [Title("Terminate Settings")]
        [OdinSerialize] GameObject DefaultCamera { get; set; }
        [OdinSerialize] Camera.Shakable Shakable { get; set; }

        [OdinSerialize] string EpilogueScene { get; set; } = "Epilogue";
        [OdinSerialize] float SceneChangeDelay { get; set; } = 3f;
        [OdinSerialize] float FadeTime { get; set; } = 1f;

        [OdinSerialize] float CameraShakeDuration { get; set; } = 0.1f;
        [OdinSerialize] float CameraShakeMagnitude { get; set; } = 1f;

        [OdinSerialize] Transform Doll { get; set; }
        [OdinSerialize] float DollYPosition { get; set; } = 0f;
        [OdinSerialize] Doll.Movable Movable { get; set; }

        [OdinSerialize] GameObject EnemySpawner1 { get; set; }
        [OdinSerialize] GameObject EnemySpawner2 { get; set; }
        [OdinSerialize] GameObject EnemySpawner3 { get; set; }
        [OdinSerialize] Transform Pot { get; set; }
        [OdinSerialize] Transform Rouge { get; set; }
        [OdinSerialize] Cache.GameCache GameCache { get; set; }
        [OdinSerialize] DB.PlayerInfo PotInfo { get; set; }
        [OdinSerialize] DB.PlayerInfo RougeInfo { get; set; }

        [OdinSerialize] Audio.BgmPlayer BgmPlayer { get; set; }
        [OdinSerialize] Audio.SEPlayer SEPlayer { get; set; }
        [OdinSerialize] AudioClip DoolAudioClip { get; set; }

        public void Terminate()
        {
            BgmPlayer.Stop();
            SEPlayer.PlayOneShot(DoolAudioClip);

            DefaultCamera.gameObject.SetActive(false);
            Shakable.gameObject.SetActive(true);
            Shakable.Shake(CameraShakeDuration, CameraShakeMagnitude);

            EnemySpawner1.gameObject.SetActive(false);
            EnemySpawner2.gameObject.SetActive(false);
            EnemySpawner3.gameObject.SetActive(false);

            Movable.enabled = false;
            var dollPosition = Doll.position;
            dollPosition.y = DollYPosition;
            if (GameCache.Scores[PotInfo] > GameCache.Scores[RougeInfo])
            {
                dollPosition.x = Rouge.position.x;
                Rouge.gameObject.SetActive(false);
            }
            else
            {
                dollPosition.x = Pot.position.x;
                Pot.gameObject.SetActive(false);
            }
            Doll.position = dollPosition;

            StartCoroutine(SceneChangeCoroutine());
        }

        IEnumerator SceneChangeCoroutine()
        {
            yield return new WaitForSeconds(SceneChangeDelay);
            FindObjectOfType<GUI.FadeManager>().LoadScene(FadeTime, EpilogueScene);
        }
    }
}