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
    public class ChargeBar : SerializedMonoBehaviour
    {
        [OdinSerialize] IChargeInfo IChargeInfo { get; set; }
        [OdinSerialize] Image FillImage { get; set; }
        [OdinSerialize] Image BackgroundImage { get; set; }

        private void Update()
        {
            FillImage.fillAmount = IChargeInfo.ChagedAmount() / IChargeInfo.MaxChageAmount();
            BackgroundImage.gameObject.SetActive(IChargeInfo.ChagedAmount() != 0f);
        }
    }
}