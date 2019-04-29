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

namespace PotAndRouge.Dev
{
    public class Memo : SerializedMonoBehaviour
    {
        [OdinSerialize, TextArea(30, 40)] string m_Text;
    }
}