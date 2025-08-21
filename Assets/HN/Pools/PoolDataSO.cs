using UnityEngine;

namespace HN.Pools
{
    [CreateAssetMenu(fileName = "PoolList", menuName = "SO/Pool/Data", order = 0)]
    public class PoolDataSO : ScriptableObject
    {
        public GameObject prefab;
        public int poolCnt;
    }
}