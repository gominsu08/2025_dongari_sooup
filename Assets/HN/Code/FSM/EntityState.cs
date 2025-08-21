using HN.Code.Entities;

namespace HN.Code.FSM
{
    public class EntityState
    {
        private EntityStateMachine _stateMachine;
        private Entity _entity;
        
        public EntityState(EntityStateMachine stateMachine, Entity entity)
        {
            _stateMachine = stateMachine;
            _entity = entity;
        }

        public virtual void Enter()
        {
            
        }
        
        public virtual void Update()
        {
            
        }
        
        public virtual void Exit()
        {
            
        }
    }
}