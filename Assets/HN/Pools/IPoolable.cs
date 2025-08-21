using UnityEngine;

namespace HN.Pools
{
    public interface IPoolable
    {
        public PoolDataSO PoolData { get; }
        public GameObject GameObject { get; }
        
        public void InitPool(Pool pool);
        public void ResetItem();
    }
}