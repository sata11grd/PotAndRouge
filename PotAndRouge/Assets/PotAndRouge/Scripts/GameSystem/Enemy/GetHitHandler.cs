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
    public class GetHitHandler : SerializedMonoBehaviour
    {
        public void GetHit(GameObject particle)
        {
            var obj = Instantiate(particle);
            obj.transform.position = transform.position;
            Destroy(gameObject);
        }
    }
}