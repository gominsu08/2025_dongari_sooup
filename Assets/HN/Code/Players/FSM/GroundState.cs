using HN.Code.Entities;
using HN.Code.FSM;
using UnityEngine;

namespace HN.Code.Players.FSM
{
    public abstract class GroundState : EntityState
    {
        protected readonly Player _player;
        protected readonly PlayerMovement _playerMovement;
        
        public GroundState(EntityStateMachine stateMachine, Entity entity) : base(stateMachine, entity)
        {
            _player = entity as Player;
            _playerMovement = _player?.GetComponentInChildren<PlayerMovement>();
        }

        public override void Enter()
        {
            base.Enter();

            _player.InputReader.OnJumpKeyPressed += HandleJumpKeyPressed;
        }

        public override void Exit()
        {
            base.Exit();
            
            _player.InputReader.OnJumpKeyPressed -= HandleJumpKeyPressed;
        }

        public override void Update()
        {
            base.Update();
            
            Vector2 movementKey = _player.InputReader.MovementKey;
            HandleMovementKey(movementKey);
        }

        protected abstract void HandleMovementKey(Vector2 movementKey);

        protected virtual void HandleJumpKeyPressed()
        {
            if(_playerMovement.CanJump)
                _player.ChangeState(PlayerState.JUMP);
        }
    }
}