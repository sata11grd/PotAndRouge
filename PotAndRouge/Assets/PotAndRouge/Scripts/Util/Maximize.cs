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

namespace PotAndRouge.Util
{
    public class Maximize : SerializedMonoBehaviour
    {
        private void Awake()
        {
            var worldHeight = Camera.main.orthographicSize * 2f;
            var worldWidth = worldHeight / Screen.height * Screen.width;
            transform.localScale = new Vector3(worldWidth, worldHeight);
        }
    }
}