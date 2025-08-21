using System.Collections.Generic;
using HN.Code.Entities;

namespace HN.Code.FSM
{
    public class EntityStateMachine
    {
        public bool CanChangeState { get; set; } = true;
        public EntityState CurrentEntityState { get; private set; }

        private Dictionary<string, EntityState> _statePairs;
        private Entity _entity;
        
        public EntityStateMachine(Entity entity)
        {
            _statePairs = new Dictionary<string, EntityState>();
        }

        public void AddState(string stateName, EntityState entityState)
        {
            _statePairs.Add(stateName, entityState);
        }

        public void UpdateCurrentState() => CurrentEntityState?.Update();

        public void ChangeState(string stateName)
        {
            if(CanChangeState == false) return;
            
            CurrentEntityState?.Exit();
            CurrentEntityState = _statePairs.GetValueOrDefault(stateName);
            CurrentEntityState?.Enter();
        }
    }
}