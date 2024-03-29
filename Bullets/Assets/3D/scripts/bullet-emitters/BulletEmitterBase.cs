﻿using game.package.utilities;
using UnityEngine;

namespace game.package.bullets
{
    public abstract class BulletEmitterBase : MonoBehaviour
    {
        [SerializeField] protected BulletBase bulletPrefab;
        [SerializeField] protected BulletFormation bulletFormation;
        [SerializeField] protected float fireRate;
        [SerializeField] protected int bulletCount = 2;
        [SerializeField] protected float bulletSpacing = 1f;
        [SerializeField] protected Vector3 muzzleOffset;
        [Range(0, 360)] [SerializeField] protected float areaAngle;
        [Range(0, 360)] [SerializeField] protected float orientationAngle;

        protected BulletFactoryManager bulletFactoryManager;
        protected BulletFactoryBase bulletFactory;
        protected BulletFactoryProfile bulletFactoryProfile;
        protected GameObjectPoolBase gameObjectPool;
        protected float fireRateElpasedTime;

        protected abstract void Initialize();
        public abstract void CreateBullet();
        
        private void Start()
        {
            Initialize();
        }
        
        private void Update()
        {
            fireRateElpasedTime += Time.deltaTime;
            if (fireRateElpasedTime > fireRate)
            {
                fireRateElpasedTime = 0;
                CreateBullet();
            }
        }

        protected virtual BulletFactoryProfile GetBulletFactoryProfile()
        {
            return new BulletFactoryProfile
            {
                parentTransform = transform,
                bulletFormation = bulletFormation,
                prefab = bulletPrefab,
                bulletCount = bulletCount,
                bulletSpacing = bulletSpacing,
                areaAngle = areaAngle,
                muzzleOffset = muzzleOffset,
                orientationAngle = orientationAngle,
            };
        }
    }
}