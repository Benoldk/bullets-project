using UnityEngine;

namespace game.package.bullets
{
    public class BulletFactoryProfile
    {
        public Transform parentTransform;
        public BulletFormation bulletFormation;
        public MonoBehaviour prefab;
        public Vector3 muzzleOffset;
        public int bulletCount;
        public float bulletSpacing;
        public float orbitAngle;
    }
}