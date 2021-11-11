using UnityEngine;

namespace game.package.bullets
{
    public class BulletFactoryProfile
    {
        public Transform parentTransform;
        public BulletFormation bulletFormation;
        public MonoBehaviour prefab;
        public int bulletCount;
        public float distance;
        public float angle;
    }
}