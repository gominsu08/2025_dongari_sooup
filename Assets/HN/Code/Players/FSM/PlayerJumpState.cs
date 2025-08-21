using HN.Code.Entities;
using HN.Code.FSM;
using UnityEngine;

namespace HN.Code.Players.FSM
{
    public class PlayerJumpState : EntityState
    {
        private readonly Player _player;
        private readonly PlayerMovement _playerMovement;
        private readonly PlayerGroundDetector _groundDetector;
        
        public PlayerJumpState(EntityStateMachine stateMachine, Entity entity) : base(stateMachine, entity)
        {
            _player = entity as Player;
            _playerMovement = _player?.GetComponentInChildren<PlayerMovement>();
            _groundDetector = _player?.GetComponentInChildren<PlayerGroundDetector>();
        }

        public override void Enter()
        {
            base.Enter();

            _player.InputReader.OnJumpKeyPressed += HandleJumpKeyPressed;
            
            _playerMovement.Jump();
            _playerMovement.DecreaseJumpCnt();
        }

        public override void Exit()
        {
            base.Exit();
            
            _player.InputReader.OnJumpKeyPressed -= HandleJumpKeyPressed;
        }

        private void HandleJumpKeyPressed()
        {
            if(_playerMovement.CanJump)
                _player.ChangeState(PlayerState.JUMP);
        }

        public override void Update()
        {
            base.Update();
            
            Vector2 movementKey = _player.InputReader.MovementKey;
            _playerMovement.MoveX(movementKey.x);
            
            if (_playerMovement.IsFalling && _groundDetector.IsGround())
            {
                _playerMovement.ResetJumpCnt();
                _player.ChangeState(PlayerState.IDLE);
            }
        }
    }
}