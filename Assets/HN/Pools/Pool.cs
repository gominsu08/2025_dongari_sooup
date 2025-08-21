using System.Collections.Generic;
using UnityEngine;

namespace HN.Pools
{
    public class Pool
    {
        private readonly Stack<IPoolable> _pools;
        private readonly Transform _parent;
        private readonly GameObject _prefab;
        
        public Pool(Transform parent, PoolDataSO poolData)
        {
            _pools = new Stack<IPoolable>();
            _parent = parent;
            _prefab = poolData.prefab;

            for (int i = 0; i < poolData.poolCnt; ++i)
            {
                GameObject newObject = GameObject.Instantiate(_prefab, parent);
                newObject.gameObject.SetActive(false);
                
                IPoolable poolable = newObject.GetComponent<IPoolable>();
                poolable.InitPool(this);
                _pools.Push(poolable);
            }
        }

        public void Push(IPoolable item)
        {
            item.GameObject.SetActive(false);
            _pools.Push(item);
        }

        public IPoolable Pop()
        {
            IPoolable item = null;

            if (_pools.Count == 0)
            {
                GameObject newObj = GameObject.Instantiate(_prefab, _parent);
                item = newObj.GetComponent<IPoolable>();
                item.InitPool(this);
            }
            else
            {
                item = _pools.Pop();
                item.GameObject.SetActive(true);
            }
            
            item.ResetItem();
            
            return item;
        }
    }
}