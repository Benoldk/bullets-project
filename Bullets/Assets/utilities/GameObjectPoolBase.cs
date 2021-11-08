using System;
using System.Collections.Generic;
using UnityEngine;

namespace game.package.utilities
{
    public abstract class GameObjectPoolBase : MonoBehaviour
    {
        protected Dictionary<Type, List<GameObject>> objectPool = new Dictionary<Type, List<GameObject>>();

        public static GameObjectPoolBase Instance { get; }

        public abstract GameObject GetGameObject<T>(T prefab) where T : MonoBehaviour;
    }
}