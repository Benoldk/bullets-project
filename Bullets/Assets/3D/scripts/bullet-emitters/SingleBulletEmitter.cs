using game.package.utilities;

namespace game.package.bullets
{
    public class SingleBulletEmitter : BulletEmitterBase
    {
        protected override void Initialize()
        {
            gameObjectPool = GameObjectPool.Instance;
            bulletFactoryProfile = new BulletFactoryProfile
            {
                parentTransform = transform,
                bulletFormation = bulletFormation,
                prefab = bulletPrefab,
                count = 1,
                distance = 0
            };
            bulletFactory = BulletFactoryManager.Instance.GetBulletFactory(bulletFactoryProfile.bulletFormation, gameObjectPool);
        }

        public override void CreateBullet()
        {
            bulletFactory.CreateBullets(bulletFactoryProfile);
        }
    }
}