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

namespace PotAndRouge.UI
{
    public class PopHandler : SerializedMonoBehaviour
    {
        [Title("Required")]
        [OdinSerialize, Required] PopCanvas PopCanvas { get; set; }

        [Title("Settings")]
        [OdinSerialize] DB.PlayerInfo PlayerInfo { get; set; }

        [Button("Pop")]
        public void Pop(PopCanvas.POP_TYPE popType, string text)
        {
            PopCanvas.ChangePopType(popType);
            PopCanvas.ChangeText("【" + PlayerInfo.Name + "】\n「" + text + "」");
            PopCanvas.gameObject.SetActive(true);
        }
    }
}