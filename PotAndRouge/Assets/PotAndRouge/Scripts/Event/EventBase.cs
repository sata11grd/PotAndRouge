using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace PotAndRouge.Event
{
    public abstract class EventBase : SerializedMonoBehaviour
    {
        [Title("Settings")]
        [OdinSerialize] bool m_DeactivateOnInvoke = true;
        [OdinSerialize] bool m_DestroyOnInvoke = false;

        public virtual void Invoke()
        {
            if (m_DeactivateOnInvoke)
            {
                gameObject.SetActive(false);
            }

            if (m_DestroyOnInvoke)
            {
                Destroy(gameObject);
            }
        }

        private void OnEnable()
        {
            Invoke();
        }
    }
}
