using HN.Code.Entities;
using HN.Code.FSM;
using UnityEngine;

namespace HN.Code.Players.FSM
{
    public class PlayerMoveState : GroundState
    {
        public PlayerMoveState(EntityStateMachine stateMachine, Entity entity) : base(stateMachine, entity)
        {
            
        }

        protected override void HandleMovementKey(Vector2 movementKey)
        {
            _playerMovement.MoveX(movementKey.x);
            
            if (movementKey.sqrMagnitude < 0.1f)
            {
                _player.ChangeState(PlayerState.IDLE);
            }
        }
    }
}