using System;
using HN.Code.Entities;
using HN.Code.FSM;
using HN.Code.Inputs;
using HN.Code.Players.FSM;
using UnityEngine;

namespace HN.Code.Players
{
    public enum PlayerState
    {
        IDLE,
        MOVE,
        JUMP,
        DEAD
    }

    public class Player : Entity
    {
        [field: SerializeField] public InputReaderSO InputReader { get; private set; }

        private EntityStateMachine _stateMachine;

        private void Awake()
        {
            _stateMachine = new EntityStateMachine(this);
            _stateMachine.AddState(PlayerState.IDLE.ToString(), new PlayerIdleState(_stateMachine, this));
            _stateMachine.AddState(PlayerState.MOVE.ToString(), new PlayerMoveState(_stateMachine, this));
        }

        private void Start()
        {
            ChangeState(PlayerState.IDLE);
        }

        private void Update()
        {
            _stateMachine?.UpdateCurrentState();
        }

        public void ChangeState(PlayerState nextState)
        {
            _stateMachine.ChangeState(nextState.ToString());
        }
    }
}