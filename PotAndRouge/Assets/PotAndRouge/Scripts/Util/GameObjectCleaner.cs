﻿using System.Collections;
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
    public class GameObjectCleaner : SerializedMonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collider)
        {
            Destroy(collider.gameObject);
        }
    }
}