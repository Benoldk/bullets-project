using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace game.package.utilities
{
    public class GameObjectPool : GameObjectPoolBase
    {
        public new static GameObjectPoolBase Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
        }

        public override GameObject GetGameObject<T>(T prefab)
        {
            Type type = typeof(T);
            if(!objectPool.ContainsKey(type))
            {
                objectPool.Add(type, new List<GameObject>());
            }

            GameObject obj = objectPool[type].FirstOrDefault(g => !g.activeInHierarchy);
            if(obj == null)
            {
                FillPool(prefab, 25);
            }
            obj = objectPool[type].FirstOrDefault(g => !g.activeInHierarchy);
            return obj;
        }

        private void FillPool<T>(T prefab, int count) where T:MonoBehaviour
        {
            for (int i = 0; i < count; i++)
            {
                GameObject gObj = Instantiate(prefab.gameObject);
                gObj.SetActive(false);
                objectPool[typeof(T)].Add(gObj);
            }
        }
    }
}