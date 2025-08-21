using HN.Code.Entities;
using HN.Code.FSM;
using UnityEngine;

namespace HN.Code.Players.FSM
{
    public class PlayerMoveState : EntityState
    {
        private readonly Player _player;

        public PlayerMoveState(EntityStateMachine stateMachine, Entity entity) : base(stateMachine, entity)
        {
            _player = entity as Player;
        }

        public override void Update()
        {
            base.Update();

            Debug.Log("move state");
            Vector2 movementKey = _player.InputReader.MovementKey;

            if (movementKey.sqrMagnitude < 0.1f)
            {
                _player.ChangeState(PlayerState.IDLE);
            }
        }
    }
}