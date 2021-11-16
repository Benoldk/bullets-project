using game.package.utilities;

namespace game.package.bullets
{
    public class BulletEmitter : BulletEmitterBase
    {
        protected override void Initialize()
        {
            gameObjectPool = GameObjectPool.Instance;
            bulletFactoryProfile = GetBulletFactoryProfile();
            bulletFactory = BulletFactoryManager.Instance.GetBulletFactory(bulletFactoryProfile.bulletFormation, gameObjectPool);
        }

        public override void CreateBullet()
        {
            bulletFactoryProfile = GetBulletFactoryProfile();
            bulletFactory.CreateBullets(bulletFactoryProfile);
        }
    }
}