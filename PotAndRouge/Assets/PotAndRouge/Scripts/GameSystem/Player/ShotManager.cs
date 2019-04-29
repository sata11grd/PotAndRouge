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
    public class ShotManager : SerializedMonoBehaviour
    {
        [Title("Required")]
        [OdinSerialize, Required] DB.PlayerInfo PlayerInfo { get; set; }

        [Title("Setting")]
        [OdinSerialize] float ShotCoolTime { get; set; } = 0.3f;
        [OdinSerialize] float MaxChargeTime { get; set; } = 3f;
        [OdinSerialize] Vector3 ShotForce { get; set; }
        [OdinSerialize] Vector3 MaxShotForce { get; set; }

        [Title("Reference")]
        [OdinSerialize] Transform CannonBallsRoot { get; set; }
        [OdinSerialize] GameObject CannonBall { get; set; }

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
                var obj = Instantiate(CannonBall);
                obj.transform.position = transform.position;
                obj.GetComponent<Rigidbody2D>().AddForce(Lerp(ShotForce, MaxShotForce, m_ChargedTime / MaxChargeTime));
                obj.transform.parent = CannonBallsRoot;

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