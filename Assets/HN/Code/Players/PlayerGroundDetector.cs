using System;
using UnityEngine;

namespace HN.Code.Players
{
    public class PlayerGroundDetector : MonoBehaviour
    {
        [SerializeField] private ContactFilter2D groundFilter;
        [SerializeField] private Vector2 boxSize;

        private Collider2D[] _result;

        private void Awake()
        {
            _result = new Collider2D[1];
        }

        public bool IsGround()
        {
            return Physics2D.OverlapBox(transform.position, boxSize, 0, groundFilter, _result) > 0;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(transform.position, boxSize);
        }
    }
}