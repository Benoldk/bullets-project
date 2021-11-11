using game.package.utilities;

namespace game.package.bullets
{
    public class LineBulletFactory : BulletFactoryBase
    {
        public LineBulletFactory(GameObjectPoolBase _gameObjectPool) : base(_gameObjectPool) { }

        public override void CreateBullets(BulletFactoryProfile profile)
        {
            float offset = profile.distance * profile.bulletCount;
            var lastPosition = profile.parentTransform.position;
            lastPosition.x -= offset * 0.5f;
            lastPosition.x += profile.prefab.transform.localScale.x * 0.5f;
            for (int i = 0; i < profile.bulletCount; i++)
            {
                var bullet = GetBulletGameObject(profile);
                if(i > 0)
                    lastPosition.x += profile.distance;
                bullet.transform.position = lastPosition;
                bullet.SetActive(true);
            }
        }
    }
}