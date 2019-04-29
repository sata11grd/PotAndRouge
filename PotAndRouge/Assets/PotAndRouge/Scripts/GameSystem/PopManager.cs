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
    public class PopManager : SerializedMonoBehaviour
    {
        [System.Serializable]
        struct PopData
        {
            public UI.PopCanvas.POP_TYPE PopType;
            public float Sec;
            public DB.PlayerInfo playerInfo;
            public string text;
        }

        [Title("Requried")]
        [OdinSerialize, Required] Dictionary<DB.PlayerInfo, UI.PopHandler> PopHandlers { get; set; } = new Dictionary<DB.PlayerInfo, UI.PopHandler>();

        [Title("Pop Data")]
        [OdinSerialize] List<PopData> PopDatas { get; set; } = new List<PopData>();

        float TimeElapsed { get; set; }

        private void Awake()
        {
            TimeElapsed = 0f;
        }

        private void Update()
        {
            TimeElapsed += Time.deltaTime;

            var removables = new List<PopData>();

            PopDatas.ForEach(data =>
            {
                if (data.Sec <= TimeElapsed)
                {
                    PopHandlers[data.playerInfo].Pop(data.PopType, data.text);
                    removables.Add(data);
                }
            });

            removables.ForEach(removable => PopDatas.Remove(removable));
        }
    }
}