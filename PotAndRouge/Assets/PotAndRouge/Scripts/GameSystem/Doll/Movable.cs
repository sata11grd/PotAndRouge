using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace PotAndRouge.GameSystem.Doll
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Movable : SerializedMonoBehaviour
    {
        private Rigidbody2D myRigidbody2D;
        private float timePassed; // 経過時間
        [SerializeField] private float speedX; //クマが横に動くスピード（微小な値でおｋ）
        [SerializeField] private float speedY; //クマが縦に動くスピード
        private float positionY; // 仮のY座標
        private float time; // 時間を入れておく変数
        [SerializeField] float positonUpdatingInterval; // 何秒毎にy座標を更新するか
        private int leftScore = 5;
        private int rightScore = 10;
        [SerializeField] private int maxScoreDifference; //クマが一番端にいるときに対応するスコアの差
        private float centerXpos; // ゲームのx座標の中心
        private float xOffsetRange; // クマが動ける範囲
        [SerializeField] private float targetPosX;
        [SerializeField] float maxDifference; // クマの位置の許容誤差（微小な値でおｋ）

        [OdinSerialize] DB.PlayerInfo LeftPlayerInfo { get; set; }
        [OdinSerialize] DB.PlayerInfo RightPlayerInfo { get; set; }

        // Start is called before the first frame update
        void Start()
        {
            centerXpos = Camera.main.transform.position.x;
            Vector3 leftTop;
            leftTop = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.transform.position.z));
            xOffsetRange = centerXpos - leftTop.x;
            myRigidbody2D = GetComponent<Rigidbody2D>();
            positionY = transform.position.y;
        }

        // Update is called once per frame
        void Update()
        {
            GetScore();
            UpdatePositionY();
            MoveToTargetPos();
            TargetUpdate(leftScore, rightScore);
        }

        private void TargetUpdate(int Lscore, int Rscore)
        {
            if(Lscore - Rscore >= maxScoreDifference)
            {
                Lscore = maxScoreDifference;
                Rscore = 0;
            }else if(Rscore - Lscore >= maxScoreDifference){
                Rscore = maxScoreDifference;
                Lscore = 0;
            }
            targetPosX = xOffsetRange * (Lscore - Rscore) / maxScoreDifference;
        }

        private void MoveToTargetPos()
        {
            if (Mathf.Abs(transform.position.x - targetPosX) < maxDifference)
            {
                Vector3 tmp = myRigidbody2D.velocity;
                tmp.x = 0;
                myRigidbody2D.velocity = tmp;
            }
            else if (transform.position.x < targetPosX)
            {
                Vector3 tmp = myRigidbody2D.velocity;
                tmp.x = speedX;
                myRigidbody2D.velocity = tmp;
            }
            else if (transform.position.x > targetPosX)
            {
                Vector3 tmp = myRigidbody2D.velocity;
                tmp.x = -speedX;
                myRigidbody2D.velocity = tmp;
            }
        }

        public void GetScore() //スコアの受け取り
        {
            var cache = FindObjectOfType<Cache.GameCache>();
            leftScore = (int)(cache.Scores[LeftPlayerInfo]);
            rightScore = (int)(cache.Scores[RightPlayerInfo]);
        }

        private void UpdatePositionY()
        {
            time += Time.deltaTime;
            positionY += speedY * Time.deltaTime;
            if(time >= positonUpdatingInterval)
            {
                time = 0;
                Vector3 tmp = transform.position;
                tmp.y = positionY;
                transform.position = tmp;
            }
        }
    }
}
