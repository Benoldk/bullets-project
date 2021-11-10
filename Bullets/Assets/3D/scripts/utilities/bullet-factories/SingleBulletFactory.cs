using game.package.utilities;

namespace game.package.bullets
{
    public class SingleBulletFactory : BulletFactoryBase
    {
        public SingleBulletFactory(GameObjectPoolBase _gameObjectPool) : base(_gameObjectPool) { }

        public override void CreateBullets(BulletFactoryProfile profile)
        {
            var bullet = GetBulletGameObject(profile);
            bullet.SetActive(true);
        }
    }
}