using UnityEngine;
using UnityEngine.Events;

namespace HN.Code.Entities
{
    public abstract class Entity : MonoBehaviour
    {
        public UnityEvent OnDeadEvent;
        
        public bool IsDead { get; protected set; }

        public virtual void Dead(bool isDead)
        {
            IsDead = isDead;
            
            if(IsDead) OnDeadEvent?.Invoke();
        }
    }
}
