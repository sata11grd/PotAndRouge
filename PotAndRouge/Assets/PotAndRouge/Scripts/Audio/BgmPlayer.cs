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
    public class BgmPlayer : AudioPlayer
    {
        public void Stop()
        {
            m_AudioSource.Stop();
        }
    }
}