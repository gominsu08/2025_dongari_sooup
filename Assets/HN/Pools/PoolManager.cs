using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HN.Pools
{
    public class PoolManager : MonoBehaviour
    {
        [SerializeField] private PoolDataListSO poolList;

        private Dictionary<PoolDataSO, Pool> _poolPairs;
        
        private void Awake()
        {
            _poolPairs = poolList.list.ToDictionary(data => data, data => new Pool(transform, data));
        }

        public void Push(IPoolable item)
        {
            Pool pool = _poolPairs.GetValueOrDefault(item.PoolData);
            pool.Push(item);
        }
        
        public T Pop<T>(PoolDataSO data) where T : IPoolable
        {
            return (T)_poolPairs.GetValueOrDefault(data).Pop();
        }
    }
}