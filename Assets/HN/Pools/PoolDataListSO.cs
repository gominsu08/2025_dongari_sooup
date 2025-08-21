using System;
using System.Collections.Generic;
using UnityEngine;

namespace HN.Pools
{
    [CreateAssetMenu(fileName = "PoolList", menuName = "SO/Pool/List", order = 0)]
    public class PoolDataListSO : ScriptableObject
    {
        public List<PoolDataSO> list;
    }
}