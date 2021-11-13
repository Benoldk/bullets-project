using game.package.utilities;

namespace game.package.bullets
{
    public class BulletEmitter : BulletEmitterBase
    {
        protected override void Initialize()
        {
            gameObjectPool = GameObjectPool.Instance;
            bulletFactoryProfile = new BulletFactoryProfile
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
            bulletFactory = BulletFactoryManager.Instance.GetBulletFactory(bulletFactoryProfile.bulletFormation, gameObjectPool);
        }

        public override void CreateBullet()
        {
            bulletFactory.CreateBullets(bulletFactoryProfile);
        }
    }
}