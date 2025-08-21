using HN.Code.Entities;
using HN.Code.FSM;
using UnityEngine;

namespace HN.Code.Players.FSM
{
    public class PlayerIdleState : EntityState
    {
        private readonly Player _player;
        
        public PlayerIdleState(EntityStateMachine stateMachine, Entity entity) : base(stateMachine, entity)
        {
            _player = entity as Player;
        }

        public override void Update()
        {
            base.Update();

            Vector2 movementKey = _player.InputReader.MovementKey;

            if (movementKey.sqrMagnitude > 0.1f)
            {
                _player.ChangeState(PlayerState.MOVE);
            }
        }
    }
}