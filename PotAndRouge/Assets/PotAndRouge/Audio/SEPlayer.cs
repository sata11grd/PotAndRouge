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

namespace PotAndRouge.Audio
{
    public class SEPlayer : AudioPlayer
    {
        public void PlayOneShot(AudioClip target, float volumeScale = 0.8f)
        {
            Debug.Assert(m_AudioSource != null);
            m_AudioSource.PlayOneShot(target, volumeScale);
        }

        public void PlayOneShot(float delay, AudioClip target, float volumeScale = 0.8f)
        {
            StartCoroutine(DelayedRun(delay, () => PlayOneShot(target, volumeScale)));
        }

        IEnumerator DelayedRun(float delay, System.Action action)
        {
            yield return new WaitForSeconds(delay);

            action.Invoke();
        }
    }
}