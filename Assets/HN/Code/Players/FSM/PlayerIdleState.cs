using HN.Code.Entities;
using HN.Code.FSM;
using UnityEngine;

namespace HN.Code.Players.FSM
{
    public class PlayerIdleState : GroundState
    {
        public PlayerIdleState(EntityStateMachine stateMachine, Entity entity) : base(stateMachine, entity)
        {
        }

        protected override void HandleMovementKey(Vector2 movementKey)
        {
            if (movementKey.sqrMagnitude > 0.1f)
            {
                _player.ChangeState(PlayerState.MOVE);
            }
        }
    }
}