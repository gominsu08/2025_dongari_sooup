using System;
using UnityEngine;

namespace HN.Code.Players
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rigid;
        [SerializeField] private float moveSpeed;
        [SerializeField] private float jumpPower;
        [SerializeField] private int maxJumpCnt;

        public bool CanJump => _remainingJumpCnt > 0;
        public bool IsFalling => rigid.linearVelocityY < -0.1f;

        private int _remainingJumpCnt;

        private void Awake()
        {
            ResetJumpCnt();
        }

        public void Jump()
        {
            StopImmediately(true);
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
        
        public void MoveX(float x)
        {
            rigid.linearVelocityX = x * moveSpeed;
        }

        public void StopImmediately(bool isStopY = false)
        {
            if(isStopY)
                rigid.linearVelocity = Vector2.zero;
            else
                rigid.linearVelocityX = 0;
        }

        public void ResetJumpCnt() => _remainingJumpCnt = maxJumpCnt;
        public void DecreaseJumpCnt() => _remainingJumpCnt--;
    }
}