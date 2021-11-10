﻿using game.package.utilities;

namespace game.package.bullets
{
    public class CircularBulletEmitter : BulletEmitterBase
    {
        protected override void Initialize()
        {
            gameObjectPool = GameObjectPool.Instance;
            bulletFactoryProfile = new BulletFactoryProfile
            {
                parentTransform = transform,
                bulletFormation = bulletFormation,
                prefab = bulletPrefab,
                count = bulletCount,
                distance = distance
            };
            bulletFactory = BulletFactoryManager.Instance.GetBulletFactory(bulletFactoryProfile.bulletFormation, gameObjectPool);
        }

        public override void CreateBullet()
        {
            bulletFactory.CreateBullets(bulletFactoryProfile);
        }
    }
}