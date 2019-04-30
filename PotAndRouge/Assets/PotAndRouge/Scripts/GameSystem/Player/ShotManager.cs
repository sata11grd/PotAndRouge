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

namespace PotAndRouge.GameSystem.Player
{
    public class ShotManager : SerializedMonoBehaviour, UI.IChargeInfo
    {
        float UI.IChargeInfo.ChagedAmount()
        {
            return m_ChargedTime;
        }

        float UI.IChargeInfo.MaxChageAmount()
        {
            return MaxChargeTime;
        }

        [Title("Required")]
        [OdinSerialize, Required] DB.PlayerInfo PlayerInfo { get; set; }

        [Title("Setting")]
        [OdinSerialize] float ShotCoolTime { get; set; } = 0.3f;
        [OdinSerialize] float MaxChargeTime { get; set; } = 3f;
        [OdinSerialize] Vector3 ShotForce { get; set; }
        [OdinSerialize] Vector3 MaxShotForce { get; set; }
        [OdinSerialize] float MaxScaleMag { get; set; } = 3f;
        [OdinSerialize] float MinMass { get; set; } = 1f;
        [OdinSerialize] float MaxMass { get; set; } = 10f;

        [Title("Reference")]
        [OdinSerialize] Transform CannonBallsRoot { get; set; }
        [OdinSerialize] GameObject CannonBall { get; set; }

        [Title("SE")]
        [OdinSerialize] Audio.SEPlayer SEPlayer { get; set; }
        [OdinSerialize] AudioClip AudioClip1 { get; set; }
        [OdinSerialize] AudioClip AudioClip2 { get; set; }
        [OdinSerialize] float VolumeScale1 { get; set; } = 0.8f;
        [OdinSerialize] float MinVolumeScale2 { get; set; } = 0.5f;
        [OdinSerialize] float MaxVolumeScale2 { get; set; } = 0.8f;

        [Title("Read Only")]
        [OdinSerialize, ReadOnly] float m_RemainingShotCoolTime { get; set; }
        [OdinSerialize, ReadOnly] float m_ChargedTime { get; set; }

        Vector3 Lerp(Vector3 a, Vector3 b, float t)
        {
            var vec = Vector3.zero;
            vec.x = Mathf.Lerp(a.x, b.x, t);
            vec.y = Mathf.Lerp(a.y, b.y, t);
            vec.z = Mathf.Lerp(a.z, b.z, t);
            return vec;
        }

        private void FixedUpdate()
        {

        }

        private void Update()
        {
            m_RemainingShotCoolTime -= Time.deltaTime;
            if (m_RemainingShotCoolTime > 0f)
            {
                return;
            }
            else
            {
                m_RemainingShotCoolTime = 0f;
            }

            if (Input.GetKeyUp(PlayerInfo.KeyConfig.ShotKey))
            {
                SEPlayer.PlayOneShot(AudioClip1, VolumeScale1);
                SEPlayer.PlayOneShot(AudioClip2, Mathf.Lerp(MinVolumeScale2, MaxVolumeScale2, m_ChargedTime / MaxChargeTime));

                var obj = Instantiate(CannonBall);
                obj.transform.position = transform.position;
                obj.GetComponent<Rigidbody2D>().mass = Mathf.Lerp(MinMass, MaxMass, m_ChargedTime / MaxChargeTime);
                obj.GetComponent<Rigidbody2D>().AddForce(Lerp(ShotForce, MaxShotForce, m_ChargedTime / MaxChargeTime));
                obj.transform.parent = CannonBallsRoot;

                var scale = Mathf.Lerp(1f, MaxScaleMag, m_ChargedTime / MaxChargeTime);
                obj.transform.localScale *= scale;

                m_RemainingShotCoolTime = ShotCoolTime;
                m_ChargedTime = 0f;
                return;
            }

            if (Input.GetKey(PlayerInfo.KeyConfig.ShotKey))
            {
                m_ChargedTime += Time.deltaTime;
            }
        }
    }
}